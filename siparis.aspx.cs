  public DataSet sepetCek()
    {
        string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
        SqlConnection baglanti = new SqlConnection(baglantiYolu);

        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandType = CommandType.Text;
        komut.CommandText = "select  UAdi, Adet, Fiyat, TFiyat from Sepet";

        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = komut;

        baglanti.Open();
        DataSet sepet = new DataSet();
        adaptor.Fill(sepet);
        baglanti.Close();

        return sepet;
    }

    public DataSet siparisToplami()
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
            DataSet siparis = siparisToplami();
            Repeater2.DataSource = siparis.Tables[0];
            Repeater2.DataBind();
        }
        else
        {
            Response.Redirect("giris.aspx");
        }
    }
