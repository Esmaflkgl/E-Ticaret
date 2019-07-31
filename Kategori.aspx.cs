public DataSet KategorileriCek()
    {
        string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();

        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandType = CommandType.Text;
        komut.CommandText = "select * from Kategoriler";

        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;

        DataSet sonuclar = new DataSet();

        baglanti.Open();
        adaptor.Fill(sonuclar);
        baglanti.Close();

        return sonuclar;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            DataSet kategoriler = KategorileriCek();
            Repeater1.DataSource = kategoriler.Tables[0];
            Repeater1.DataBind();
        }
        else
            Response.Redirect("giris.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("urunlisteleme.aspx");
    }
