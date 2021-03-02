using MazeGenerator.Creators;
using System;
using System.Windows.Forms;

namespace MazeGenerator.Util
{
    public partial class MazeToolbox : Form
    {
        #region Constructor

        public MazeToolbox()
        {
            InitializeComponent();
            cbxStartSide.SelectedIndex = 0;
            cbxExitSide.SelectedIndex = 1;
            cbxMazeType.SelectedIndex = 0;
            nudSeed.Value = 0;
        }

        #endregion

        #region Delegate

        public delegate void CreateCalledHandler(int width, 
                                                 int height, 
                                                 int run, 
                                                 int seed, 
                                                 DefaultCreator.Directions start,
                                                 DefaultCreator.Directions end,
                                                 DefaultCreator.MazeTypes type,
                                                 int roomDensity,
                                                 int roomDistance,
                                                 int roomMinSize,
                                                 int roomMaxSize);

        #endregion

        #region Events

        public event CreateCalledHandler CreateCalled;

        #endregion

        #region Private Methods

        private void OnCreateCalled()
        {
            if (CreateCalled == null) return;

            DefaultCreator.Directions startDirection = (DefaultCreator.Directions)cbxStartSide.SelectedIndex;
            DefaultCreator.Directions endDirection = (DefaultCreator.Directions)cbxExitSide.SelectedIndex;
            DefaultCreator.MazeTypes type = (DefaultCreator.MazeTypes)cbxMazeType.SelectedIndex;

            CreateCalled((int)nudWidth.Value, 
                         (int)nudHeight.Value, 
                         tkbRun.Value, 
                         (int)nudSeed.Value, 
                         startDirection, 
                         endDirection, 
                         type, 
                         (int)nudRoomDensity.Value, 
                         (int)nudRoomDistance.Value, 
                         (int)nudRoomMinSize.Value, 
                         (int)nudRoomMaxSize.Value);
        }

        #endregion

        #region Signed Events Methods

        private void MazeToolbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tkbRun_ValueChanged(object sender, EventArgs e)
        {
            lblRun.Text = "Run - " + tkbRun.Value.ToString("0");
        }

        private void btnCreation_Click(object sender, EventArgs e)
        {
            OnCreateCalled();
        }

        #endregion
    }
}
