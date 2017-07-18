using System;
using System.Windows.Forms;

#region CrystalReports Using
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
#endregion

namespace lobby.Forms
{
    public partial class frmReport : Form
    {
        int reservationID, resvStatus;
        DateTime dateFrom, dateTo;
        string ctGroup;
        public frmReport(int reportNumber_, int resvID_, DateTime from_, DateTime to_, int status_, string ctGroup_)
        {
            InitializeComponent();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            reservationID = resvID_;
            dateFrom = from_;
            dateTo = to_;
            resvStatus = status_;
            ctGroup = ctGroup_;

            switch (reportNumber_)
            {
                case 1:
                    this.Text = "Huéspedes en casa";
                    printInHouse();
                    break;
                case 2:
                    this.Text = "Llegadas";
                    printArrivals();
                    break;
                case 3:
                    this.Text = "Carta de confirmación";
                    printConfLetter();
                    break;
                case 4:
                    this.Text = "Reservas";
                    printReservations();
                    break;
                case 5:
                    this.Text = "Salidas";
                    printDepartures();
                    break;
                case 6:
                    this.Text = "Revenue por grupo de transacción";
                    printRevenueByTCGroup();
                    break;
                case 7:
                    this.Text = "Tarjeta de registro";
                    printRegCard();
                    break;
                case 8:
                    this.Text = "Resumen de cuenta del huésped";
                    printGuestAccount();
                    break;
                case 9:
                    this.Text = "Noches vendidas - Revenue";
                    printRoomNightsAndRevenue();
                    break;
            }
        }

        private void printRoomNightsAndRevenue()
        {
            ReportDocument rptRoomNights = new ReportDocument();

            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "fromDate";
            paramDiscreteValue.Value = dateFrom.ToString("yyyy-MM-dd");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "toDate";
            paramDiscreteValue.Value = dateTo.ToString("yyyy-MM-dd");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crvReport.ParameterFieldInfo = paramFields;
            rptRoomNights.Load(@"c:\lobby\reports\rptRoomNightsAndRevenue.rpt");
            crvReport.ReportSource = rptRoomNights;
        }

        private void printGuestAccount()
        {
            ReportDocument rptGuestAccount = new ReportDocument();
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "resvID";
            paramDiscreteValue.Value = reservationID;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crvReport.ParameterFieldInfo = paramFields;
            rptGuestAccount.Load(@"c:\lobby\reports\rptGuestAccount.rpt");
            crvReport.ReportSource = rptGuestAccount;
        }

        private void printRegCard()
        {
            ReportDocument rptRegCard = new ReportDocument();
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "resvID";
            paramDiscreteValue.Value = reservationID;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crvReport.ParameterFieldInfo = paramFields;
            rptRegCard.Load(@"c:\lobby\reports\rptRegCard.rpt");
            crvReport.ReportSource = rptRegCard;
        }
        private void printRevenueByTCGroup()
        {
            ReportDocument rptRevenue = new ReportDocument();

            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "fromDate";
            paramDiscreteValue.Value = dateFrom.ToString("dd/MM/yyyy");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "toDate";
            paramDiscreteValue.Value = dateTo.ToString("dd/MM/yyyy");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "ctGroup";
            paramDiscreteValue.Value = ctGroup;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crvReport.ParameterFieldInfo = paramFields;
            rptRevenue.Load(@"c:\lobby\reports\rptRevenueByCTGroup.rpt");
            crvReport.ReportSource = rptRevenue;
        }

        private void printDepartures()
        {
            ReportDocument rptDepartures = new ReportDocument();

            rptDepartures.Load(@"c:\lobby\reports\rptDepartures.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = DateTime.Now.ToString("dd/MM/yyyy");
            crParameterFieldDefinitions = rptDepartures.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["departureDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);

            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crvReport.ReportSource = rptDepartures;
        }

        private void printInHouse()
        {
            ReportDocument rptInHouseGuests = new ReportDocument();
            rptInHouseGuests.Load(@"c:\lobby\reports\rptInHouseGuests.rpt");
            crvReport.ReportSource = rptInHouseGuests;
            crvReport.Refresh();
            rptInHouseGuests.Refresh();
        }

        private void printReservations()
        {
            ReportDocument rptReservations = new ReportDocument();

            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "dateFrom";
            paramDiscreteValue.Value = dateFrom.ToString("dd/MM/yyyy");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "dateTo";
            paramDiscreteValue.Value = dateTo.ToString("dd/MM/yyyy");
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "resvStatus";
            paramDiscreteValue.Value = resvStatus;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crvReport.ParameterFieldInfo = paramFields;
            rptReservations.Load(@"c:\lobby\reports\rptReservations.rpt");
            crvReport.ReportSource = rptReservations;
        }

        private void printArrivals()
        {
            ReportDocument rptArrivals = new ReportDocument();

            rptArrivals.Load(@"c:\lobby\reports\rptArrivals.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = DateTime.Now.ToString("dd/MM/yyyy");
            crParameterFieldDefinitions = rptArrivals.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["arrivalDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);

            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crvReport.ReportSource = rptArrivals;
        }

        private void printConfLetter()
        {
            ReportDocument rptConfLetter = new ReportDocument();
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "resvID";
            paramDiscreteValue.Value = reservationID;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crvReport.ParameterFieldInfo = paramFields;
            rptConfLetter.Load(@"c:\lobby\reports\rptConfLetter.rpt");

            rptConfLetter.SetParameterValue(0, reservationID);

            System.IO.Directory.CreateDirectory(@"c:\lobby\cartas_confirmacion");
            string auxPath = "c:\\lobby\\cartas_confirmacion\\carta_conf_" + reservationID.ToString() + ".pdf";
            rptConfLetter.ExportToDisk(ExportFormatType.PortableDocFormat, auxPath);

            crvReport.ReportSource = rptConfLetter;

            //Exporto la carta a PDF y la guardo en c:\cartas_confirmacion\
            //borrar
            //cambiar la ruta por el nombre FINAL del programa

        }
    }
}
