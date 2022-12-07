using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace ZoologicoV2
{
    public partial class Form1 : Form
    {
        //CONEXION BASE DE DATOS
        static string conexionbd = "Data Source=DESKTOP-R2B8L38;Initial Catalog=zoologico;Integrated Security=True";
        SqlConnection con = new SqlConnection(conexionbd);
        SqlCommand cmd;
        SqlDataReader dr;

        private void GraftCategorias() { 
        cmd=new SqlCommand(conexionbd);
        }  
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CREACION DE CRUD PARA INSERTAR EN LA BASE DE DATOS Y LIMPIAR LOS CAMPOS USADOS DE LA TABLA ZOO
            string cadena = "Insert into zoo ([nombre_zoo],[ciudad],[pais],[tamaño_m2],[presupuesto_anual])" +
                " values ('" + tb_nombrezoo.Text + "','" + tb_ciudadzoo.Text + "','" + tb_paiszoo.Text + "','" + tb_tamanozoo.Text + "','" + tb_presupuesto.Text + "')";
            SqlCommand comando = new SqlCommand(cadena, con);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se realizo exitosamente el registro del zoologico: " + tb_nombrezoo.Text);
            tb_nombrezoo.Text = "";
            tb_ciudadzoo.Text = "";
            tb_paiszoo.Text = "";
            tb_tamanozoo.Text = "";
            tb_presupuesto.Text = "";
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            //BOTON PARA ENCENDER LA BASE DE DATOS. SE DEBE ENCENDER PRIMERO PARA CUALQUIER ITERACION CON LA BD
            con.Open();
            MessageBox.Show("La Conexion a la base de datos: " + con.Database + "  ha sido exitosa");

        }

        private void btn_desconectar_Click(object sender, EventArgs e)
        {
            //BOTON PARA CERRAR LA BASE DE DATOS.
            con.Close();
            MessageBox.Show("Se ha desconectado correctamente");
        }

        private void btn_insertaranimal_Click(object sender, EventArgs e)
        {
            //CREACION DE CRUD PARA INSERTAR EN LA BASE DE DATOS Y LIMPIAR LOS CAMPOS USADOS DE LA TABLA ANIMAL
            string cadena = "Insert into animal ([nombre_vulgar],[nombre_cientifico],[familia],[peligro_extincion],[Id_zoo],[especie],[sexo],[año_nacimiento],[pais_origen],[continente])" +
                " values ('" + tb_nombrev.Text + "','" + tb_nombrec.Text + "','" + tb_familia.Text + "','" + tb_peligroext.Text + "','" + tb_idzoo.Text + "','" + tb_especie.Text + "','" + tb_sexo.Text + "','" + tb_fechanacimiento.Text + "','" + tb_paisorigen.Text + "','" + tb_continente.Text + "')";
            SqlCommand comando = new SqlCommand(cadena, con);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se realizo exitosamente el registro del Animal: " + tb_nombrev);
            tb_nombrev.Text = "";
            tb_nombrec.Text = "";
            tb_familia.Text = "";
            tb_peligroext.Text = "";
            tb_idzoo.Text = "";
            tb_especie.Text = "";
            tb_sexo.Text = "";
            tb_fechanacimiento.Text = "";
            tb_paisorigen.Text = "";
            tb_continente.Text = "";
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            if (tb_buscarpeligro.Text == "")
            {
                string query = "Select * from animal";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
            else {
                string query = "select [especie],[peligro_extincion] from animal where peligro_extincion='"+tb_buscarpeligro.Text+"'";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
