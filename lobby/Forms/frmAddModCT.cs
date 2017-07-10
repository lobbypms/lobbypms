using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmAddModCT : Form
    {
        bool agrega;
        int ctID;
        string ctTipo;
        
        public frmAddModCT(bool add_, int codigoTransaccionId)
        {
            InitializeComponent();
            agrega = add_;
            
            cmbSubGroup.DataSource = AdminCTSubgrupos.TraerTodos();
            cmbSubGroup.DisplayMember = "Codigo";
            cmbSubGroup.ValueMember = "Codigo";

            ctSubgrupo ctSubgrupo = AdminCTSubgrupos.TraerPorCodigo(cmbSubGroup.SelectedValue.ToString());
            ctGrupo ctGrupo = AdminCTGrupos.TraerPorId(ctSubgrupo.CTGrupoId);
            txbCTGroup.Text = ctGrupo.Descripcion;

            
            if (agrega)
            {
                this.Text = "Agregar código de transacción";
                btnAddModCT.Text = "Agregar";
                cmbCTType.SelectedIndex = 0;
            }
            else
            {
                this.Text = "Modificar código de transacción";
                btnAddModCT.Text = "Modificar";

                ctID = codigoTransaccionId;
                var codigoTransaccionMod = AdminCodigosTransaccion.TraerPorId(codigoTransaccionId);

                txbCTCode.Text = codigoTransaccionMod.Codigo;
                
                //TODO agregar columna ACTIVO para inhabilitar el CT
                txbCTCode.Enabled = false;
                txbCTDesc.Text = codigoTransaccionMod.Descripcion;
                cmbSubGroup.SelectedIndex = codigoTransaccionMod.SubgrupoId - 1;
                txbCTGroup.Text = AdminCTGrupos.TraerPorId(codigoTransaccionMod.GrupoId).Codigo;
                cbGeneratesTax.Checked = codigoTransaccionMod.GenIVA;

                switch (codigoTransaccionMod.Tipo)
                {
                    case "T":
                        cmbCTType.SelectedIndex = 0;
                        break;
                    case "I":
                        cmbCTType.SelectedIndex = 1;
                        break;
                    case "P":
                        cmbCTType.SelectedIndex = 2;
                        break;
                    case "A":
                        cmbCTType.SelectedIndex = 3;
                        break;
                    default:
                        cmbCTType.SelectedIndex = 0;
                        break;
                }
            }
        }

        private void cmbSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctSubgrupo ctSubgrupo = AdminCTSubgrupos.TraerPorCodigo(cmbSubGroup.SelectedValue.ToString());

            if (ctSubgrupo != null)
            {
                ctGrupo ctGrupo = AdminCTGrupos.TraerPorId(ctSubgrupo.CTGrupoId);
                txbCTGroup.Text = ctGrupo.Descripcion;
            }
        }

        private void btnAddModCT_Click(object sender, EventArgs e)
        {
            switch (cmbCTType.SelectedIndex)
            {
                case 0:
                    ctTipo = "T";
                    break;
                case 1:
                    ctTipo = "I";
                    break;
                case 2:
                    ctTipo = "P";
                    break;
                case 3:
                    ctTipo = "A";
                    break;
                default:
                    ctTipo = "T";
                    break;
            }

            if (agrega)
            {
                if (txbCTCode.Text == "" || txbCTCode.Text == "")
                    MessageBox.Show("No puede haber campos vacíos", "Completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    CodigoTransaccion codigoTransaccion = new CodigoTransaccion()
                    {
                        Codigo = txbCTCode.Text,
                        Descripcion = txbCTDesc.Text,
                        SubgrupoId = AdminCTSubgrupos.TraerPorCodigo(cmbSubGroup.SelectedValue.ToString()).Id,
                        GrupoId = AdminCTSubgrupos.TraerPorCodigo(cmbSubGroup.SelectedValue.ToString()).CTGrupoId,
                        GenIVA = cbGeneratesTax.Checked,
                        Tipo = ctTipo
                    };

                    try
                    {
                        AdminCodigosTransaccion.Agregar(codigoTransaccion);
                        MessageBox.Show("Código agregado con éxito", "Agregar código transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                    }
                }
            }
            else
            {
                CodigoTransaccion codigoTransaccion = new CodigoTransaccion()
                {
                    Id = ctID,
                    Codigo = txbCTCode.Text,
                    Descripcion = txbCTDesc.Text,
                    GrupoId = AdminCTGrupos.TraerPorId(AdminCTSubgrupos.TraerPorCodigo(cmbSubGroup.SelectedValue.ToString()).CTGrupoId).Id,
                    SubgrupoId = AdminCTSubgrupos.TraerPorCodigo(cmbSubGroup.SelectedValue.ToString()).Id,
                    GenIVA = cbGeneratesTax.Checked,
                    Tipo = ctTipo
                };

                AdminCodigosTransaccion.Modificar(codigoTransaccion);
                MessageBox.Show("Código modificado con éxito", "Modificar código transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txbCTCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cmbCTType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCTType.SelectedIndex == 3 || cmbCTType.SelectedIndex == 2 || cmbCTType.SelectedIndex == 1)
            {
                cbGeneratesTax.Checked = false;
                cbGeneratesTax.Visible = false;
            }
            else
            {
                cbGeneratesTax.Checked = true;
                cbGeneratesTax.Visible = true;
            }
        }
    }
}
