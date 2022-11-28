using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ASMaIoP.Client.View.Pages;
using ASMaIoP.Client.Models.Utilities;
using ASMaIoP.Models.Utilities;
using ASMaIoP.Models.Network;
using ASMaIoP.Client.Models.Network;
using ASMaIoP.Models;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Data;

namespace ASMaIoP.Client.ViewModels
{

    public class EditJob : INotifyPropertyChanged
    {
        private class JobInfo
        {
            public int JobId;
            public int JobLevel;
            public string Title;
            public int Salary;
        }

        public class EmployeeInfo
        {
            public int EmployeeId;
            public string Name;
            public string Surname;
            public int jodId;
        }

        List<JobInfo> JobsInfo = new List<JobInfo>();
        List<EmployeeInfo> employees = new List<EmployeeInfo>();

        string selectedJobTitle;
        string selectedJobSalary;

        string SelectedJobTitle
        {
            get => selectedJobTitle;
            set 
            {
                selectedJobTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedJobTitle)));
            }
        }

        string SelectedJobSalary
        {
            get=>selectedJobSalary;
            set
            {
                selectedJobSalary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedJobSalary)));
            }
        }

        public List<EmployeeInfo> GetUsersDeleteJob(int nJobID)
        {
            List<EmployeeInfo> emp = new List<EmployeeInfo>();

            foreach(EmployeeInfo inf in employees)
            {
                if(inf.jodId == nJobID)
                {
                    emp.Add(inf);
                }
            }

            return emp;
        }

        public void LoadUsers()
        {
            try
            {
                Packet packet = new Packet();
                //������������� ��� ������
                packet.SetPacketType(PacketType.CREATE_PROF_USERS);
                //��������� � ����� ���� ������� ������
                packet.AddInt(ApplicationAPIs.session.SessionId);

                //��������� ���������� � ��������
                if (!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("���� ������");
                }

                //��������� ����� ������
                ApplicationAPIs.session.Write(packet.GetBytes());

                // �������� ���������� ����������
                int nCountEmployee = ApplicationAPIs.session.ReadInt();

                // ������� � ���� ����� �������� ���� ����������
                for (int i = 0; i < nCountEmployee; i++)
                {
                    //�������� id ��������
                    int EmployeeId = ApplicationAPIs.session.ReadInt();
                    //�������� ��� ���������
                    string Name = ApplicationAPIs.session.ReadString();
                    // ������� ������� ���������
                    string Surname = ApplicationAPIs.session.ReadString();
                    // �������� ��� ���������
                    int JobId = ApplicationAPIs.session.ReadInt();
                    // ��������� ��� � ����

                    employees.Add(new EmployeeInfo { EmployeeId = EmployeeId, Name = Name, Surname = Surname, jodId = JobId });
                }

                // ��������� ���������� � ��������
                ApplicationAPIs.session.Close();
            }
            catch(Exception ex)
            {
                // ��������� ���������� � ��������
                ApplicationAPIs.session.Close();

                MessageBox.Show(ex.Message);
            }
        }
        
        public void FormLoaded()
        {
            LoadUsers();
            LoadJobs();
        }

        PageRightCreateJob parent;

        public EditJob(PageRightCreateJob form)
        {
            this.parent = form;
        }

        //����!
        public void LoadJobs()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("JobTitle");
                dt.Columns.Add("Id");
                Packet packet = new Packet();
                packet.SetPacketType(PacketType.ADMIN_ROLES_GET);

                //��������� � ����� ���� ������� ������
                packet.AddInt(ApplicationAPIs.session.SessionId);

                //��������� ���������� � ��������
                if (!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("���� ������");
                }

                //��������� ����� ������
                ApplicationAPIs.session.Write(packet.GetBytes());

                int nCount = ApplicationAPIs.session.ReadInt();

                for(int i = 0; i < nCount; i++)
                {
                    int nRoleID = ApplicationAPIs.session.ReadInt();
                    int nRoleSalary = ApplicationAPIs.session.ReadInt();
                    int nRoleLvl = ApplicationAPIs.session.ReadInt();
                    string RoleTitle = ApplicationAPIs.session.ReadString();

                    JobsInfo.Add(new JobInfo { JobId = nRoleID, JobLevel = nRoleLvl, Title = RoleTitle,Salary = nRoleSalary  });

                    DataRow dr = dt.NewRow(); 
                    dr["JobTitle"] = RoleTitle;
                    dr["Id"] = nRoleID;

                    dt.Rows.Add(dr);
                }

                ApplicationAPIs.session.Close();

                parent.ProfTumbler.DataContext = dt;
                parent.ProfTumbler.DisplayMemberPath = dt.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                // ��������� ���������� � ��������
                ApplicationAPIs.session.Close();

                MessageBox.Show(ex.Message);
            }
        }

        public void LoadJob(int JobID)
        {
            foreach(JobInfo inf in JobsInfo)
            {
                if(inf.JobId == JobID)
                {
                    parent.NameJob.Text = inf.Title;
                    parent.Salary.Text = inf.Salary.ToString();
                    parent.LvlAccess.SelectedIndex = inf.JobLevel-1;
                }
            }
        }

        public void edJob(int JobID, string JobTitle, int nSalary, int nRoleLvl)
        {
            try
            {
                Packet packet = new Packet();
                JobTitle = JobTitle.Replace("\f", String.Empty);
                JobTitle = JobTitle.Replace("\0", String.Empty);
                packet.SetPacketType(PacketType.ADMIN_ROLES_EDIT);

                //��������� � ����� ���� ������� ������
                packet.AddInt(ApplicationAPIs.session.SessionId);

                //��������� ���������� � ��������
                if (!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("���� ������");
                    return;
                }

                packet.AddInt(JobID);
                packet.AddInt(nRoleLvl);
                packet.AddInt(nSalary);
                packet.AddString(JobTitle);

                ApplicationAPIs.session.Write(packet.GetBytes());

                int bIsSuccesss = ApplicationAPIs.session.ReadInt();

                // ��������� ������� �� ������������ ��������������
                if (bIsSuccesss == 1)
                {
                    MessageBox.Show("������������ ������� ������!");
                }
                else
                {
                    MessageBox.Show("������ �� ������� �������� ������ ������������!");
                }

                //��������� ����������
                ApplicationAPIs.session.Close();
            }
            catch(Exception ex)
            {
                //��������� ����������
                ApplicationAPIs.session.Close();

                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteJobs(int JobID)
        {
            try
            {
                Packet packet = new Packet();
                packet.SetPacketType(PacketType.ADMIN_ROLE_REMOVE);

                //��������� � ����� ���� ������� ������
                packet.AddInt(ApplicationAPIs.session.SessionId);

                //��������� ���������� � ��������
                if (!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("���� ������");
                }

                packet.AddInt(JobID);

                ApplicationAPIs.session.Write(packet.GetBytes());

                int bIsSuccesss = ApplicationAPIs.session.ReadInt();

                // ��������� ������� �� ������������ ��������������
                if (bIsSuccesss == 1)
                {
                    MessageBox.Show("��������� ������� �������!");
                }
                else
                {
                    LoadUsers();
                    MessageBox.Show("������ �� ������� ������� ������ ������������!");
                }
            }
            catch(Exception ex)
            {
                //��������� ����������
                ApplicationAPIs.session.Close();

                MessageBox.Show(ex.Message);
            }
        }

        public void CreateJobs(int nJobLevel, string JobTitle, int nSalary)
        {
            try
            {
                Packet packet = new Packet();
                packet.SetPacketType(PacketType.ADMIN_ROLE_CREATE);
                //��������� � ����� ���� ������� ������
                packet.AddInt(ApplicationAPIs.session.SessionId);

                packet.AddInt(nJobLevel);
                packet.AddInt(nSalary);
                packet.AddString(JobTitle);

                //��������� ���������� � ��������
                if (!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("���� ������");
                    return;
                }

                //��������� ����� ������
                ApplicationAPIs.session.Write(packet.GetBytes());

                int nStatus = ApplicationAPIs.session.ReadInt();
                if(nStatus != 1)
                {
                    MessageBox.Show("������ ������ �����������");
                }

                // ��������� ���������� � ��������
                ApplicationAPIs.session.Close();
            }
            catch (Exception ex)
            {
                //��������� ����������
                ApplicationAPIs.session.Close();

                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
