using System;

namespace Conexion
{
    public partial class JugadoresClubes : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
