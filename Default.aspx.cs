using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mathkids
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlogin"] != null)
            {
                Session["userlogin"] = null;
            }

            //login(this, new EventArgs());
        }

        protected void login(object sender, EventArgs e)
        {
            bool bandexito = true;
            bool bandverifypassword = false;

            try
            {
                //validar conexion

                var myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
                myConnection.Open();

                String InsertCmd = "";
                SqlTransaction myTrans = myConnection.BeginTransaction();

                try
                {
                    //querys
                    InsertCmd = "	select distinct cuentas.cuentaID " +
                                "			   from cuentas with(nolock) " +
                                "			  where cuentas.usuario = '" + usuario.Value + "' ";
                    SqlCommand sqlCommand = new SqlCommand(InsertCmd, myConnection);

                    try
                    {
                        //ejecucion de consultas
                        sqlCommand.Transaction = myTrans;
                        sqlCommand.CommandTimeout = 5000;
                        sqlCommand.ExecuteNonQuery();

                        SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataSet myDataSet = new DataSet();
                        myDataAdapter.Fill(myDataSet, "cuentas");

                        bool banduserexits = false;
                        if (myDataSet.Tables["cuentas"].Rows.Count > 0)
                        {
                            if (myDataSet.Tables["cuentas"].Rows[0]["cuentaID"] != null)
                            {
                                banduserexits = true;                                
                            }
                        }

                        if (banduserexits)
                        {
                            try
                            {
                                //querys
                                InsertCmd = "	select distinct cuentas.cuentaID " +
                                            "			   from cuentas with(nolock) " +
                                            "			  where cuentas.usuario = '" + usuario.Value + "' and passw = '" + password.Value + "' ";
                                sqlCommand = new SqlCommand(InsertCmd, myConnection);

                                try
                                {
                                    sqlCommand.Transaction = myTrans;
                                    sqlCommand.CommandTimeout = 5000;
                                    sqlCommand.ExecuteNonQuery();

                                    SqlDataAdapter myDataAdapter1 = new SqlDataAdapter(sqlCommand);
                                    DataSet myDataSet1 = new DataSet();
                                    myDataAdapter1.Fill(myDataSet1, "cuentas");
                                    
                                    if (myDataSet1.Tables["cuentas"].Rows.Count > 0)
                                    {
                                        if (myDataSet1.Tables["cuentas"].Rows[0]["cuentaID"] != null)
                                        {
                                            bandverifypassword = true;
                                        }

                                    }

                                    if (bandverifypassword)
                                    {
                                        Session["userlogin"] = (int)myDataSet1.Tables["cuentas"].Rows[0]["cuentaID"];                                     
                                    } else
                                    {
                                        lblerror.Text = "usuario o contraseña incorrecta.";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    bandexito = false;
                                    lblerror.Text = "E5: " + ex.Message;
                                }
                            } catch (Exception ex)
                            {
                                bandexito = false;
                                lblerror.Text = "E4: " + ex.Message;
                            }
                            
                        } else
                        {
                            lblerror.Text = "El usuario no existe";
                        }
                    } catch (Exception ex)
                    {
                        bandexito = false;
                        lblerror.Text = "E3: " + ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    bandexito = false;
                    lblerror.Text = "E2: " + ex.Message;
                }

                if (bandexito)
                {
                    myTrans.Commit();
                }
                else
                {
                    myTrans.Rollback();
                }

                myConnection.Close();
            } catch(Exception ex)
            {
                bandexito = false;
                lblerror.Text = "E1: "  + ex.Message;
            }

            if (bandverifypassword)
            {
                Response.Redirect("~/juego.aspx");
            }

            /*if(!bandexito)
            {
                lblerror.Visible = true;
            }*/
        }
    }
}
