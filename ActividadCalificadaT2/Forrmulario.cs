using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActividadCalificadaT2
{
    public partial class Forrmulario : Form
    {
        private GestionMedicamento gestMed;
        public Forrmulario()
        {
            InitializeComponent();
            gestMed = new GestionMedicamento();
        }

        public bool ValidarCampos()
        {
            if (txtCodigo.Text.Trim().Length == 0)
            {
                MessageBox.Show("El codigo es requerido.");
                return false;
            }
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("El nombre es requerido.");
                return false;
            }
            if (txtCantidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("La cantidad es requerido.");
                return false;
            }
            if (txtPrecioUnitario.Text.Trim().Length == 0)
            {
                MessageBox.Show("El precio unitario es requerido.");
                return false;
            }

            return true;
        }

        public void LimpiarCasillas()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
        }

        public void ListarTodos()
        {
            GridTable.Rows.Clear();
            for (int i = 0; i<gestMed.getIndice();i++)
            {
                Medicamento med = gestMed.Obtener(i);
                GridTable.Rows.Add(med.p_codigo , med.p_nombre , med.p_cantidad , med.p_precioUnitario,
                    (med.p_cantidad * med.p_precioUnitario));
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == false)
            {
                return;
            }
            Medicamento med = new Medicamento();
            med.p_codigo = txtCodigo.Text.Trim();
            med.p_nombre = txtNombre.Text.Trim();
            med.p_cantidad = Convert.ToInt32(txtCantidad.Text.Trim()); 
            med.p_precioUnitario =Convert.ToDouble(txtPrecioUnitario.Text.Trim());

            if (gestMed.Buscar(med.p_codigo) == -1)
            {
                MessageBox.Show("Registro correcto.");
                gestMed.Registrar(med);
                ListarTodos();
                LimpiarCasillas();
            }
            else
            {
                MessageBox.Show("El codigo "+med.p_codigo+" ya se encuentra registrado.");
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            gestMed.Ordenar();
            ListarTodos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nome = txtNombre.Text.Trim();

            if (nome.Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre de medicamento a buscar.");
            }
            else
            {
                int pos = gestMed.Buscar(nome);

                if (pos != -1)
                {
                    Medicamento med = gestMed.Obtener(pos);
                    string result = "";

                    result += "Codigo: " + med.p_codigo + "\n";
                    result += "Nombre: " + med.p_nombre + "\n";
                    result += "Cantidad: " + med.p_cantidad + "\n";
                    result += "Precio Unitario: " + med.p_precioUnitario + "\n";

                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("El nombre del medicamento " + nome + " no existe.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string cod = txtCodigo.Text.Trim();

            if (cod.Length == 0)
            {
                MessageBox.Show("Debe ingresar un codigo a consultar.");
            }
            else
            {
                int pos = gestMed.Buscar(cod);

                if (pos != -1)
                {
                    gestMed.Eliminar(cod);
                    ListarTodos();
                    MessageBox.Show("Se eliminó datos del medicamento con codigo "+cod);
                }
                else
                {
                    MessageBox.Show("El codigo " + cod + " no existe.");
                }
            }
        }
    }
}
