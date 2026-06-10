using BE.Composite;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Roles
    {
        DAL_Roles dal_roles = new DAL_Roles();

        public void GuardarArbol(RolComposite raiz, string descripcionRaiz)
        {

            //dal_roles.LimpiarTablas();

            // La raíz es el nodo "Roles" (virtual) — sus hijos son los roles reales
            foreach (var hijo in raiz.Hijos())
            {
                if (hijo is RolComposite rol)
                    GuardarRolRecursivo(rol, idPadre: null, descripcion: descripcionRaiz);
            }
        }

        private void GuardarRolRecursivo(RolComposite rol, int? idPadre, string descripcion)
        {
            int idRol;

            // Si ya tiene ID, existe en BD — no insertar, solo registrar jerarquía si corresponde
            if (rol.Id > 0)
            {
                idRol = rol.Id;
            }
            else
            {
                // Es nuevo — insertar
                idRol = dal_roles.InsertarRol(rol.Nombre, descripcion);
                rol.Id = idRol;
            }


            // 2. Si tiene padre, registrar la jerarquía
            if (idPadre.HasValue)
                dal_roles.AsignarRolHijo(idPadre.Value, idRol);

            // 3. Recorrer hijos
            foreach (var hijo in rol.Hijos())
            {
                if (hijo is RolComposite subRol)
                {
                    GuardarRolRecursivo(subRol, idPadre: idRol, descripcion: null);
                }
                else if (hijo is Permiso permiso)
                {
                    int idPermiso;

                    if (permiso.Id > 0)
                    {
                        // Ya existe en BD — solo asignar al rol
                        idPermiso = permiso.Id;
                    }
                    else
                    {
                        // Es nuevo — insertar
                        idPermiso = dal_roles.InsertarPermiso(permiso.Nombre);
                        permiso.Id = idPermiso;
                        permiso.IdPermiso = idPermiso;
                    }

                    dal_roles.AsignarPermisoARol(idRol, idPermiso);
                }
            }
        }

        public RolComposite CargarArbol()
        {
            var (dtRoles, dtPermisos, dtRolRol, dtRolPermiso) = dal_roles.CargarArbol();

            var roles = new Dictionary<int, RolComposite>();
            var permisos = new Dictionary<int, Permiso>();

            // Crear todos los roles
            foreach (DataRow row in dtRoles.Rows)
            {
                roles[Convert.ToInt32(row["IdRol"])] = new RolComposite
                {
                    Id = Convert.ToInt32(row["IdRol"]),
                    Nombre = row["Nombre"].ToString()
                };
            }

            // Crear todos los permisos
            foreach (DataRow row in dtPermisos.Rows)
            {
                int id = Convert.ToInt32(row["IdPermisos"]);
                permisos[id] = new Permiso
                {
                    Id = id,
                    IdPermiso = id,
                    Nombre = row["Nombre"].ToString()
                };
            }

            // Asignar permisos a sus roles
            foreach (DataRow row in dtRolPermiso.Rows)
            {
                int idRol = Convert.ToInt32(row["IdRol"]);
                int idPerm = Convert.ToInt32(row["IdPermisos"]);
                if (roles.ContainsKey(idRol) && permisos.ContainsKey(idPerm))
                    roles[idRol].Agregar(permisos[idPerm]);
            }

            // Construir jerarquía rol-rol
            var rolesConPadre = new HashSet<int>();
            foreach (DataRow row in dtRolRol.Rows)
            {
                int idPadre = Convert.ToInt32(row["IdRolPadre"]);
                int idHijo = Convert.ToInt32(row["IdRolHijo"]);
                if (roles.ContainsKey(idPadre) && roles.ContainsKey(idHijo))
                {
                    roles[idPadre].Agregar(roles[idHijo]);
                    rolesConPadre.Add(idHijo);
                }
            }

            // Raíz virtual: roles sin padre
            var raiz = new RolComposite { Id = 0, Nombre = "Roles" };
            foreach (var kvp in roles)
            {
                if (!rolesConPadre.Contains(kvp.Key))
                    raiz.Agregar(kvp.Value);
            }

            return raiz;
        }


        public List<RolComposite> ObtenerRoles()
        {
            DataTable dtRoles = dal_roles.ObtenerTodosLosRoles();

            List<RolComposite> lista = new List<RolComposite>();


            foreach (DataRow row in dtRoles.Rows)
            {
                lista.Add(new RolComposite
                {
                    Id = Convert.ToInt32(row["IdRol"]),
                    Nombre = row["Nombre"].ToString()
                });
            }
            return lista;
        }


        public List<Permiso> ObtenerPermisos()
        {
            var dtPermisos = dal_roles.ObtenerTodosLosPermisos();

            var permisos = new List<Permiso>();

            foreach (DataRow row in dtPermisos.Rows)
            {
                int id = Convert.ToInt32(row["IdPermisos"]);
                permisos.Add(new Permiso
                {
                    Id = id,
                    IdPermiso = id,
                    Nombre = row["Nombre"].ToString()
                });
            }
            return permisos;
        }

        public void EliminarComponente(RolComposite padre, Componente componente)
        {
            if (padre.Id == 0)
            {
                return;
                //La raiz no tiene padre real, nada que desasignar.
            }
            if (componente is RolComposite rolHijo)
            {
                dal_roles.DesasignarRolHijo(padre.Id, rolHijo.Id);
            }

            if (componente is Permiso permiso)
            {
                dal_roles.DesasignarPermisoDeRol(padre.Id, permiso.Id);
            }
        }

        public void EliminarRol(int id)
        {
            dal_roles.EliminarRol(id);
        }


        public void ModificarPermiso(int idPermiso, string nuevoNombre)
        {
            dal_roles.ModificarPermiso(idPermiso, nuevoNombre);
        }

        public void EliminarPermiso(int id)
        {
            dal_roles.EliminarPermisos(id);
        }





        //// USUARIOS
        ///
        public void AgregarRolUsuario(int idUsuario, int idRol)
        {
            dal_roles.AgregarRolUsuario(idUsuario, idRol);
        }

        public List<RolComposite> ObtenerRolesDeUsuario(int idUsuario)
        {
            // Reutilizamos el árbol completo ya construido
            RolComposite arbolCompleto = CargarArbol();

            // Obtenemos los IDs de roles asignados al usuario
            DataTable dtRoles = dal_roles.ObtenerRolesPorUsuario(idUsuario);

            var idsRolesUsuario = new HashSet<int>();

            foreach (DataRow row in dtRoles.Rows)
                idsRolesUsuario.Add(Convert.ToInt32(row["IdRol"]));

            // Se busca en el arbol y los devuelve en una lista
            var rolesUsuario = new List<RolComposite>();

            foreach (var hijo in arbolCompleto.Hijos())
            {
                if (hijo is RolComposite rol && idsRolesUsuario.Contains(rol.Id))
                    rolesUsuario.Add(rol);
            }

            return rolesUsuario;
        }

        public void QuitarRolUsuario(int idUsuario, int idRol)
        {
            dal_roles.QuitarRolUsuario(idUsuario, idRol);
        }
    }
}
