﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CelluleMutante2.Controls;


namespace CelluleMutante2
{
    public partial class Form1 : Form
    {
        Panel pnl_main;
        Button btn_simulation;
        Cell cell;
        Timer MyTimer;

        public Form1()
        {
            InitializeComponent();

            // Initialisation d’un Panel en utilisant notre classe 
            pnl_main = new MainPanel();
            pnl_main.Location = new Point((Size.Width - pnl_main.Width) / 2 - 10, (Size.Height - pnl_main.Height) / 2 - 40);
            pnl_main.Anchor = AnchorStyles.None;

            // Initialisation d’un Button en utilisant notre classe 
            btn_simulation = new SimulationButton();
            btn_simulation.Location = new Point(90, 390);
            btn_simulation.Anchor = AnchorStyles.None;

            cell = new Cell();
            MyTimer = new Timer();
            MyTimer.Interval = (600);
            MyTimer.Tick += new EventHandler(UpdateCell);

            // Ajout des éléments à notre fenêtre 
            Controls.Add(pnl_main);
            Controls.Add(btn_simulation);

            pnl_main.Anchor = AnchorStyles.None;
            pnl_main.Paint += new PaintEventHandler(pnl_main_Paint);

            btn_simulation.Anchor = AnchorStyles.None;
            btn_simulation.Click += new EventHandler(btn_simulation_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Définir la taille et le titre de la fenêtre
            Size = new Size(700, 600);
            Text = "Cellule Mutante";
        }

        private void pnl_main_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(pnl_main.BackColor);
            SolidBrush coloredBrush = new SolidBrush(cell.color);
            g.FillEllipse(coloredBrush, pnl_main.Width / 2 - (cell.size / 2), pnl_main.Width / 2 - (cell.size/2), cell.size, cell.size);
            g.Dispose();
        }

        private void btn_simulation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La simulation commence");
            MyTimer.Start();
        }

        private void UpdateCell(object sender, EventArgs e)
        {
            cell.Mutation();
            this.Refresh();
        }
    }
}
