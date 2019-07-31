public DataSet sepetCek()
    {
        string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
        SqlConnection baglanti = new SqlConnection(baglantiYolu);

        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandType = CommandType.Text;
        komut.CommandText = "select Uadi, Adet, Fiyat, TFiyat from Sepet";

        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;

        baglanti.Open();
        DataSet sepet = new DataSet();
        adaptor.Fill(sepet);
        baglanti.Close();

        return sepet;
    }

    public DataSet sepetToplam()
    {
        string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
        SqlConnection baglanti = new SqlConnection(baglantiYolu);

        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandType = CommandType.Text;
        komut.CommandText = "select sum(TFiyat) as SepetToplami from Sepet";

        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;

        baglanti.Open();
        DataSet sepettop = new DataSet();
        adaptor.Fill(sepettop);
        baglanti.Close();

        return sepettop;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            DataSet sepet = sepetCek();
            Repeater1.DataSource = sepet.Tables[0];
            Repeater1.DataBind();
        }
        else
        {
            Response.Redirect("giris.aspx");
        }

        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            DataSet toplam = sepetToplam();
            Repeater2.DataSource = toplam.Tables[0];
            Repeater2.DataBind();
        }
        else
        {
            Response.Redirect("giris.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("sepeteatma.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("sepetguncelle.aspx");
    }
