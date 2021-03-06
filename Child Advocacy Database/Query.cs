﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Child_Advocacy_Database
{
    public partial class Query : Form
    {
        // Most of this form is in testing phase. 

        // TODO: Link database to search
        // TODO: Figure out edit options
        // TODO: Link 'open file' to listbox selection
        // TODO: Link search button to status and check for problems
        // TODO: Link database to delete (deleteBtn_Click function)
        // TODO: ?? lots more


        Case queryCase;
        List<Case> queryCases;
        List<string> hdd = new List<string>();
        public bool editFlag;

        //
        // Intitialization and add drive list to the select hdd listbox
        //
        public Query()
        {
            InitializeComponent();
            queryCases = new List<Case>();
            queryCase = new Case();
            editFlag = false;

            try
            {
                DriveInfo[] myDrives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in myDrives)
                {
                    if (drive.IsReady)
                        selectHddListBox.Items.Add(drive.Name + " " + drive.VolumeLabel);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception message: " + e.Message);
            }
        }

        // 
        // Selects the hard drives and adds them to the hard drive list if they are not duplicates
        //
        private void selectHddListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool addHddFlag;
            string addHdd;
            string tempHdd = "";


            statusLbl.ForeColor = Color.Green;
            statusLbl.Text = "**Status: Enter search criteria.";
            selectHddListBox.BackColor = Color.White;


            addHddFlag = false;
            if (selectHddListBox.SelectedIndex != -1)
            {
                tempHdd = selectHddListBox.SelectedItem.ToString();
            }
            addHdd = "";
            if (tempHdd.Length > 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    addHdd += tempHdd[j];
                }

                if (hdd.Count == 0)
                {
                    hdd.Add(addHdd);
                }
                else
                {
                    addHddFlag = true;
                    for (int i = 0; i < hdd.Count; i++)
                    {
                        if (hdd[i].Contains(addHdd))
                        {
                            addHddFlag = false;
                        }
                    }
                }
            }
            if (addHddFlag)
            {
                hdd.Add(addHdd);
            }

            confirmHddListBox.Items.Clear();
            foreach (var h in hdd)
            {
                confirmHddListBox.Items.Add(h);
            }
        }

        //
        // Remove a hard drive from the hard drive list and update the confirm hdd listbox
        //
        private void removeHddBtn_Click(object sender, EventArgs e)
        {
            if (confirmHddListBox.SelectedIndex != -1)
            {
                string deletedHdd = confirmHddListBox.SelectedItem.ToString();

                int indexToDelete = -1;
                for(int i = 0; i < hdd.Count; i++)
                {
                    if(deletedHdd == hdd[i])
                    {
                        indexToDelete = i;
                    }
                }
                if (indexToDelete != -1)
                {
                    hdd.RemoveAt(indexToDelete);
                }
                confirmHddListBox.Items.RemoveAt(confirmHddListBox.SelectedIndex);

                confirmHddListBox.Items.Clear();
                foreach (var h in hdd)
                {
                    confirmHddListBox.Items.Add(h);
                }
                statusLbl.ForeColor = Color.Green;
                statusLbl.Text = "**Status: Enter search criteria.";
            }
            else
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please select a hard drive from the list to remove.";
            }
        }

        //
        // Reset the color of the NCA# textbox
        //
        private void ncaNumTxt_TextChanged(object sender, EventArgs e)
        {
            ncaNumTxt.BackColor = Color.White;
            statusLbl.ForeColor = Color.Green;
            statusLbl.Text = "**Status: Enter search criteria.";
        }

        //
        // Search for selected criteria
        //
        private void searchBtn_Click(object sender, EventArgs e)
        {
            //
            // queryCase data members to search for
            //

            if (!checkDateFormat(childDobTxt.Text) && childDobTxt.Text != "")
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please enter child DOB in the exact format MM/DD/YYYY or leave blank if unknown.";
                childDobTxt.BackColor = Color.Red;
            }
            else if (!checkDateFormat(interviewTxt.Text) && interviewTxt.Text != "")
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please enter interview date in the exact format MM/DD/YYYY or leave blank if unknown.";
                interviewTxt.BackColor = Color.Red;
            }
            else
            {

                queryCase = new Case();
                queryCase.CaseNum = ncaNumTxt.Text;
                queryCase.ChildFirst = childFirstNameTxt.Text;
                queryCase.ChildLast = childLastNameTxt.Text;
                queryCase.ChildDob = childDobTxt.Text;
                queryCase.Guardian1First = g1FirstNameTxt.Text;
                queryCase.Guardian1Last = g1LastNameTxt.Text;
                queryCase.Guardian2First = g2FirstNameTxt.Text;
                queryCase.Guardian2Last = g2LastNameTxt.Text;
                queryCase.InterviewDate = interviewTxt.Text;
                queryCase.PerpFirstName = perpFirstTxt.Text;
                queryCase.PerpLastName = perpLastTxt.Text;
                queryCase.PerpNick = perpNickTxt.Text;
                queryCase.SiblingFirstName = siblingFirstNameTxt.Text;
                queryCase.SiblingLastName = siblingLastNameTxt.Text;
                queryCase.OtherVictimFirstName = otherVictimFirstNameTxt.Text;
                queryCase.OtherVictimLastName = otherVictimLastNameTxt.Text;

                XmlDb database = new XmlDb();
                queryCases = database.Query(queryCase);
 
                searchResultListBox.Items.Clear();
                foreach (var caseList in queryCases)
                {
                    searchResultListBox.Items.Add(caseList.ToString()); // Overloaded ToString for queryCase class to print out the NCA and child first/last name
                }
                statusLbl.ForeColor = Color.Blue;
                statusLbl.Text = "**Status: Search complete, if any cases were found they have been added to the list.";
            }
        }

        //
        // Remove the folders associated with the NCA# on all selected hard drives
        //
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            bool deletedSuccess = false;
            if (hdd.Count == 0)
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please choose which hard drive to remove the database entry.";
                selectHddListBox.BackColor = Color.Red;
            }
            else if (ncaNumTxt.Text == "")
            {
                ncaNumTxt.BackColor = Color.Red;
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please enter a NCA# to remove.";
            }
            else
            {
                // Confirmation message box
                if (MessageBox.Show("Permanently delete NCA# " + ncaNumTxt.Text + " and ALL associated files from ALL selected hard drives?\n" +
                        "This cannot be undone!", "Remove from database",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < hdd.Count; i++)
                        {
                            if (Directory.Exists(hdd[i] + ncaNumTxt.Text))
                            {
                                Directory.Delete(hdd[i] + ncaNumTxt.Text, true); // 'true' means to delete subfiles
                                
                                // Remove from DB
                                XmlDb database = new XmlDb();
                                database.Delete(ncaNumTxt.Text);

                                deletedSuccess = true;
                            }
                        }
                        if (deletedSuccess)
                        {
                            MessageBox.Show("NCA# " + ncaNumTxt.Text + " deleted!");
                        }
                        else
                        {
                            statusLbl.ForeColor = Color.Red;
                            statusLbl.Text = "**Status: Error in file removal- folder not found.";
                            MessageBox.Show("NCA# " + ncaNumTxt.Text + " folder not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLbl.ForeColor = Color.Red;
                        statusLbl.Text = "**Status: Error in file removal- see exception message for details.";
                        MessageBox.Show("Exception message: " + ex.Message);
                    }
                }
            }
        }

        //
        // Clear/reset the form
        //
        private void clearFormBtn_Click(object sender, EventArgs e)
        {
            ncaNumTxt.Clear();
            childFirstNameTxt.Clear();
            childLastNameTxt.Clear();
            childDobTxt.Clear();
            g1FirstNameTxt.Clear();
            g1LastNameTxt.Clear();
            g2FirstNameTxt.Clear();
            g2LastNameTxt.Clear();
            perpFirstTxt.Clear();
            perpLastTxt.Clear();
            perpNickTxt.Clear();
            interviewTxt.Clear();
            siblingFirstNameTxt.Clear();
            siblingLastNameTxt.Clear();
            otherVictimFirstNameTxt.Clear();
            otherVictimLastNameTxt.Clear();
            searchResultListBox.Items.Clear();
            selectHddListBox.BackColor = Color.White;
            confirmHddListBox.BackColor = Color.White;
            queryCases = null;
            queryCases = new List<Case>();
            statusLbl.ForeColor = Color.Green;
            statusLbl.Text = "**Status: Enter search criteria.";
            // Would be nice to reset tab order to 0 here 
        }

        //
        // Exit to dashboard
        //
        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashForm = new Dashboard();
            dashForm.Show();
            this.Close();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {

            // Opens File Explorer after confirming item is selected in list box. 
            if (searchResultListBox.SelectedIndex == -1)
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please select a case from the list to open.";
            }
            else if (hdd.Count == 0)
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please add the hard drive(s) to search.";
                selectHddListBox.BackColor = Color.Red;
            }
            else
            {
                bool isDirectoryFound = false;
                try
                {
                    foreach (var h in hdd)
                    {
                        if (Directory.Exists(h + ncaNumTxt.Text))
                        {
                            Process.Start("explorer.exe", h + ncaNumTxt.Text);
                            isDirectoryFound = true;
                        }
                    }
                    if (isDirectoryFound)
                    {
                        statusLbl.ForeColor = Color.Blue;
                        statusLbl.Text = "**Status: Directory found, opening...";
                    }
                    else
                    {
                        statusLbl.ForeColor = Color.Red;
                        statusLbl.Text = "**Status: Directory with NCA# " + ncaNumTxt.Text + " was not found, try adding another hard drive to the list to search.";
                    }
                }
                catch (Exception ex)
                {
                    statusLbl.ForeColor = Color.Red;
                    statusLbl.Text = "**Status: " + ex.Message;
                }
            }
        }

        private void searchResultListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a search result is clicked then it will populate the textboxes with the List<DatabaseItem> queryCases[searchResultsListBox.SelectedIndex]
            // That way everything associated with the search can be seen as there is too much to fit into the listbox
            // 
            if (searchResultListBox.SelectedIndex != -1)
            {
                ncaNumTxt.Text = queryCases[searchResultListBox.SelectedIndex].CaseNum;
                childFirstNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].ChildFirst;
                childLastNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].ChildLast;
                childDobTxt.Text = queryCases[searchResultListBox.SelectedIndex].ChildDob;
                g1FirstNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].Guardian1First;
                g1LastNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].Guardian1Last;
                g2FirstNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].Guardian2First;
                g2LastNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].Guardian2Last;
                interviewTxt.Text = queryCases[searchResultListBox.SelectedIndex].InterviewDate;
                perpFirstTxt.Text = queryCases[searchResultListBox.SelectedIndex].printPerpFirst(); // Populate the textboxes, can press down arrow if it doesn't all fit
                perpLastTxt.Text = queryCases[searchResultListBox.SelectedIndex].printPerpLast();
                perpNickTxt.Text = queryCases[searchResultListBox.SelectedIndex].printPerpNick();
                siblingFirstNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].printSiblingFirst();
                siblingLastNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].printSiblingLast();
                otherVictimFirstNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].printOtherVictimFirst();
                otherVictimLastNameTxt.Text = queryCases[searchResultListBox.SelectedIndex].printOtherVictimLast();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            // This will change to be when a listboxitem is selected and populates the textboxes,
            // that will be the query to send to edit, there needs to be a flag to check if the search was completed
            if (searchResultListBox.SelectedIndex != -1)
            {
                editFlag = true;
                AddCaseForm editCase = new AddCaseForm(queryCases[searchResultListBox.SelectedIndex]);
                statusLbl.ForeColor = Color.Green;
                statusLbl.Text = "**Status: Editing the most recently searched case.";
                editCase.Show();
                editCase.BringToFront();
                this.Close();
            }
            else
            {
                statusLbl.ForeColor = Color.Red;
                statusLbl.Text = "**Status: Please search for a case and choose it from the list box before attempting to edit.";
            }
        }

        //
        // Check the date format
        //
        public bool checkDateFormat(string date)
        {
            if (date.Length == 10)
            {
                if (
                    (date[0] >= '0' && date[0] <= '9') &&
                    (date[1] >= '0' && date[1] <= '9') &&
                    (date[2] == '/') &&
                    (date[3] >= '0' && date[3] <= '9') &&
                    (date[4] >= '0' && date[4] <= '9') &&
                    (date[5] == '/') &&
                    (date[6] >= '0' && date[6] <= '9') &&
                    (date[7] >= '0' && date[7] <= '9') &&
                    (date[8] >= '0' && date[8] <= '9') &&
                    (date[9] >= '0' && date[9] <= '9')
                   )
                {
                    return true;
                }
            }
            return false;
        }

        //
        // Change color of child DOB
        //
        private void childDobTxt_TextChanged(object sender, EventArgs e)
        {
            childDobTxt.BackColor = Color.White;
            statusLbl.ForeColor = Color.Green;
            statusLbl.Text = "**Status: Enter search criteria.";
        }

        //
        // Change color of interview text
        //
        private void interviewTxt_TextChanged(object sender, EventArgs e)
        {
            interviewTxt.BackColor = Color.White;
            statusLbl.ForeColor = Color.Green;
            statusLbl.Text = "**Status: Enter search criteria.";
        }
    }
}