using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Testdb
{ 
    class MyApplicationContext : ApplicationContext
{
    private void onFormClosed(object sender, EventArgs e)
    {
        if (Application.OpenForms.Count == 0)
        {
            ExitThread();
        }
    }

    public MyApplicationContext()
    {
        

        var forms = new List<Form>() {
            new Form1(),
            new Form2(),
            new Form3(),
            new Form4()
        };
        foreach (var form in forms)
        {
            form.FormClosed += onFormClosed;
        }

        
        forms[3].Show();


    }
}

    static class Program
    {

        
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyApplicationContext());

        }
    }
}
