namespace BE
{
    public class Permiso : Component
    {
        public int IdPermiso
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }

        public TipoPermiso Tipo 
        {
            get; set;
        }

        public override bool TienePermiso(string Permiso)
        {
            return Nombre == Permiso;
        }
    }
}
