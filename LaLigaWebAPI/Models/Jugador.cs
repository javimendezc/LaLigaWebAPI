using System;

namespace LaLigaWebAPI.Models
{
    //public enum E_POSICION
    //{
    //    [Description("Portero")] PORTERO = 1,
    //    [Description("Defensa")] DEFENSA = 2,
    //    [Description("Centrocampista")] CENTROCAMPISTA = 3,
    //    [Description("Delantero")] DELANTERO = 4
    //}

    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Posicion { get; set; }
        //public E_POSICION Posicion { get; set; }

        ////Método para acceder a la descripción de cada miembro de la enumeración
        //public static string GetEnumDescription(Enum value)
        //{
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        //    if (attributes != null && attributes.Any())
        //    {
        //        return attributes.First().Description;
        //    }

        //    return value.ToString();
        //}
    }
}