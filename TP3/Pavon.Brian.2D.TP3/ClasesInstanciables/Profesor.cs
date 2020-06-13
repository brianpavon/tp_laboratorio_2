using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        public Profesor()
        {
               
        }
        static Profesor()
        {
            random = new Random();                
        }

        public Profesor(int id,string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<EClases>();

            for (int i = 0; i <= 2 ; i++)
            {
                this._randomClases();
            }

        }

        private void _randomClases()
        {
            int claseAsignada = random.Next(0, Enum.GetNames(typeof(EClases)).Length-1);
            this.clasesDelDia.Enqueue((EClases)claseAsignada);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();

        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Clases del dia");
            foreach (EClases aux in this.clasesDelDia)
            {
                sb.AppendLine(aux.ToString());
            }
            
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }


        public static bool operator == (Profesor i, EClases e)
        {
            bool retorno = false;
            foreach (EClases aux in i.clasesDelDia)
            {
                if(aux == e)
                {
                    retorno = true;
                }
            }
            
            return retorno;
        }

        public static bool operator != (Profesor i, EClases e)
        {
            return !(i == e);
        }


    }
}
