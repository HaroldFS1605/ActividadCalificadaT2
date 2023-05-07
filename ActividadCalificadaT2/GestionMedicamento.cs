using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadCalificadaT2
{
    public class GestionMedicamento
    {
        private Medicamento[] arreglo; //SE DEFINE EL ARREGLO
        private int indice; //CREACION DE LA VARIABLE INDICE

        public GestionMedicamento() //CONSTRUCTOR DE LA CLASE GestionMedicamento
        {
            arreglo = new Medicamento[1000];//inicializar y crear el arreglo
            indice = 0;
        }

        public void Registrar(Medicamento obj) //Almacenamos la estructura medicamento al arreglo
        {
            if (indice < arreglo.Length)
            {
                arreglo[indice] = obj;  
                indice++;
            }
        }

        public void Ordenar() //Se aplica el método burbuja para comparar el nombre de la estructura medicamento y ordenando en forma ascendente  
        {
            for (int i = 0; i<indice;i++)
            {
                for (int j = 0; j<indice-1;j++)
                {
                    if (arreglo[j].p_nombre.ToUpper().CompareTo(arreglo[j+1].p_nombre.ToUpper()) > 0)
                    {
                        Medicamento aux = arreglo[j];
                        arreglo[j] = arreglo[j + 1];    
                        arreglo[j+1] = aux;
                    }
                }
            }
        }

        public int Buscar(string nome) //Busca en base al nombre del medicamento aplicando la búsqueda secuencial
        {
            int pos = 0;
            bool bandera = false;
            while (pos < indice && bandera == false)
            {
                if (nome.ToUpper().Equals(arreglo[pos].p_nombre.ToUpper()))
                {
                    bandera = true;
                    break;
                }
                pos++;
            }

            if (bandera == false)
            {
                return -1;
            }
            else
            {
                return pos;
            }
        }
        public int BuscarPorCodigo(string nome) //Aplica la búsqueda secuencial usando el código
        {
            int pos = 0;
            bool bandera = false;
            while (pos < indice && bandera == false)
            {
                if (nome.ToUpper().Equals(arreglo[pos].p_codigo.ToUpper()))
                {
                    bandera = true;
                    break;
                }
                pos++;
            }

            if (bandera == false)
            {
                return -1;
            }
            else
            {
                return pos;
            }
        }

        public void Eliminar(string code) //Este método elimina un elemento del arreglo, pero antes busca el elemento por código. Decrementa el índice
        {
            int pos = BuscarPorCodigo(code);

            if (pos !=-1)
            {
                for (int i = pos; i<indice-1;i++)
                {
                    arreglo[i] = arreglo[i + 1];
                }
                indice--;
            }
        }

        public int getIndice() //retornar la cantidad de elementos que tiene el arreglo
        {
            return indice;
        }

        public Medicamento Obtener(int i) //obtiene el elemento del arreglo en base a su posición.
        {
            return arreglo[i];
        }
    }
}
