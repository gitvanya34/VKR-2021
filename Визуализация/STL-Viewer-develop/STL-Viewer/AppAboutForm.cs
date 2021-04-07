/**
  ******************************************************************************
  * @file    AppAboutForm.cs
  * @author  Ali Batuhan KINDAN
  * @date    19.02.2020
  * @brief   This file is contains the functionality of application About window
  ******************************************************************************
  */

using System;
using System.Windows.Forms;

namespace STLViewer
{
    public partial class AppAboutForm : Form
    {
        public AppAboutForm()
        {
            InitializeComponent();
            CenterToScreen(); // open center of the screen
           
        }

        private void CloseBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
      
        }

        private void AuthorEMailLb_Click(object sender, EventArgs e)
        {

        }
    }
}
