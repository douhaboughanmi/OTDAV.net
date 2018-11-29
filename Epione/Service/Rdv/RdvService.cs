using Data.Infrastructure;
using Domain;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Rdv
{
 public   class RdvService : Service<rendezvou>, IRdvService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public RdvService() : base(uow)
        {
                
        }

        public void generatePDF(int id)
        {


            var risk = (from rh in dbf.DataContext.rendezvous
                        where(id==rh.id)
                        select new
                        {
                            date = rh.date,
                            sujet = rh.sujet,
                            description = rh.desciption,
                            etat = rh.etat

                        }).ToList();

            int y = 90;
            int x = 50;
            DateTime d = new DateTime();
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 8, XFontStyle.BoldItalic);
           // gfx.DrawString("Rapport des taux de risques durant ce mois de " + risk.First().nom + " " + risk.First().prenom, font, XBrushes.Red, 200, y);
            foreach (var i in risk)
            {
               // if (i.etat.Equals("validé") && i.date == d)

                //{

                    y += 30;

                    gfx.DrawString("Date du rendez vous  : " + i.date, font, XBrushes.Black, 200, y);
                    y += 30;
                    gfx.DrawString("Sujet :" + i.sujet, font, XBrushes.Black, 200, y);

                    y += 30;
                    gfx.DrawString("description :" + i.description, font, XBrushes.Black, 200, y);
                   

                //}
            }

            document.Save(@"D:\testpdf.pdf");

        }




   
    }
/*
    public IEnumerable<rendezvou>getAll()
    {
        return dbf.getRepository<rendezvou>().GetMany.ToList();
    }
    */
}
