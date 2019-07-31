using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();

        string Email = TextBox1.Text;
        string Sifre = TextBox2.Text;

        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandType = CommandType.Text;
        komut.CommandText = "select * from Musteri where Email=@pemail and Sifre=@psifre";

        komut.Parameters.AddWithValue("@pemail", Email);
        komut.Parameters.AddWithValue("@psifre", Sifre);

        baglanti.Open();
        SqlDataReader dr = komut.ExecuteReader();

        if (dr.HasRows == true)
        {
            
            while (dr.Read())
            {
                string adi = dr["Ad"].ToString();
                string soyadi = dr["Soyad"].ToString();
                Response.Write("Hoşgeldin" + adi + soyadi);
                Session["giris"] = true;
                Session["Email"] = Email;
                Session["Ad"] = adi;
                Session["Soyad"] = soyadi;

                Response.Redirect("kategori.aspx");
            }
        }
        else
        {
            Response.Write("Yanlış kullanıcı adı veya şifresi");
        }
        baglanti.Close();
    }
}
