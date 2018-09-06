using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler;
using System.Security.Cryptography;


namespace DataHandler
{
   public class UserOptions : IDisposable
    {
       private string tempconnection;
        /// <summary>
        /// Creates new user
        /// </summary>
        /// 
        ContabilidadEntities usercont;
        
        public UserOptions(string connection)
        {
            tempconnection = connection;
 usercont = new ContabilidadEntities(connection);

        }

        public UserOptions()
        {
         usercont = new ContabilidadEntities();

        }

        Byte[] Salt = { 0x01, 0x11,0x22,0x33,0x44,0x55,0x66,0x77 };
        public void Dispose()
        {
            if (usercont != null)
            {
                usercont.Dispose();
                usercont = null;
            }
        }

        public bool SaveChanges()
        {
            usercont = new ContabilidadEntities();
            try
            {
 usercont.SaveChanges();
                
                usercont.Dispose();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public bool AddUser(Users newuser)
        {
            usercont = new ContabilidadEntities();
            try
            {
                usercont.Users.Add(newuser);
                usercont.SaveChanges();

                
                usercont.Dispose();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }



        }

        public bool AddUserInit(Users newuser)
        {
            // Permissions aa = new Permissions();
            //   aa.PermissionsID = Permissionsp;


            usercont = new ContabilidadEntities(tempconnection);
          



            try
            {
                usercont.Users.Add(newuser);
                usercont.SaveChanges();

                int newuserid = usercont.Users.ToArray()[usercont.Users.ToArray().Length - 1].UserID;

                CompaniesOptions companies = new CompaniesOptions(tempconnection);
                CompaniesSet[] complist = companies.GetCompanies();

                for (int i = 0; i < complist.Length; i++)
                {
                    usercont.UserCompanies.Add(new UserCompanies() { CompaniID = complist[i].CompanyId, UserID = newuserid, Active = false });
                }
                usercont.SaveChanges();
                usercont.Dispose();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }



        }
        public bool AddUser(string Namep, string LastNamep, string Loginp, UserCompanies CompanyIdp, string Notesp, UserType Permissionsp,string Emailp,byte [] Passwordp)
        {
            Permisions aa = new Permisions();

            usercont = new ContabilidadEntities();
           

            try
            {
                var newuser = new Users
                {
                    Name = Namep,
                    LastName = LastNamep,
                    ActiveUser = true,
                    UserCompanies = CompanyIdp.Users.UserCompanies,
                    Notes = Notesp,
                    Login = Loginp,
                    UserType = Permissionsp,
                Email = Emailp,
                Password = Passwordp
                


                

            };

            usercont.Users.Add(newuser);
            usercont.SaveChanges();
                usercont.Dispose();

                




                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
            
            
        }
        public bool AdduserCompany(UserCompanies newuserCompany)
        {
            usercont = new ContabilidadEntities();
           
            try
            {
                usercont.UserCompanies.Add(newuserCompany);
                usercont.SaveChanges();
                usercont.Dispose();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }
        public Byte[] GenerateHash(string password, int length)
        {
            using (var derivedbytes = new Rfc2898DeriveBytes(password, Salt))
            {
                return derivedbytes.GetBytes(length+8);
            }




        }
        /// <summary>
        /// Deletes user
        /// </summary>
        public bool DeleteUser(string UserId)
        {
            
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Creates new user
        /// </summary>
        public bool ModifyUser(Users Olduser, Users EditedUser)
        {
            usercont = new ContabilidadEntities();
           
            try
            {
 usercont.Entry(Olduser).CurrentValues.SetValues(EditedUser);
                usercont.SaveChanges();
                usercont.Dispose();
                return true; 
      
            }
            catch (Exception)
            {

                return false;
            }
             }
        public bool ModifyUserComp(UserCompanies OlduserC, UserCompanies EditedUserC)
        {
            usercont = new ContabilidadEntities();
           
            try
            {
                usercont.UserCompanies.Attach(OlduserC);
                usercont.Entry(OlduserC).CurrentValues.SetValues(EditedUserC);
                usercont.SaveChanges();
                //usercont.Dispose();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Users[] GetUsers()
        {

            usercont = new ContabilidadEntities();

            var userlist = (from db in usercont.Users
                            select db).ToArray();
     
            usercont.Dispose();
            return userlist;



        }
        public Users[] GetActiveUsers()
        {


         usercont = new ContabilidadEntities();

            var userlist = (from db in usercont.Users
                            where db.ActiveUser == true
                            select db).ToArray();
         
            usercont.Dispose();
            return userlist;



        }
        public Users[] GetUsers(int execpID)
        {
            usercont = new ContabilidadEntities();


            var userlist = (from db in usercont.Users
                            where db.UserID != execpID
                            select db).ToArray();
            usercont.Dispose();
            return userlist;
       
           


        }

        public Users GetUserby_Login(string login)
        {

            usercont = new ContabilidadEntities();
        


            var userlist = (from db in usercont.Users
                            where db.Login == login
                            where db.ActiveUser == true
                            select db).ToArray();
           // usercont.Dispose();
            if (userlist.Length != 0)
                return userlist[0];
            return new Users();



        }

        public Users GetUserby_ID(int id)
        {

            usercont = new ContabilidadEntities();

            var userlist = (from db in usercont.Users
                            where db.UserID == id
                            select db).ToArray()[0];
 usercont.Dispose();
            return userlist;
           



        }

        public void UpdateUserCompStatus(UserCompanies usercomp)
        {


        }

        public UserCompanies getUserComp(int useriD, int CompID)
        {
            usercont = new ContabilidadEntities();
            var usercomp = (from db in usercont.UserCompanies
                           where (db.UserID == useriD)&(db.CompaniID ==CompID)
                           select db).ToArray()[0];
           // usercont.Dispose();
            return usercomp;
                           
        }

        public UserCompanies [] getUserCompList(int useriD)
        {
            usercont = new ContabilidadEntities();
            var usercompList = (from db in usercont.UserCompanies
                            where (db.UserID == useriD)
                            select db).ToArray();
            //usercont.Dispose();
            return usercompList;

        }

        public UserCompanies getUserComp(int usercompiD)
        {
            usercont = new ContabilidadEntities();
            var usercompList = (from db in usercont.UserCompanies
                                where (db.UserCompanyID == usercompiD)
                                select db).Single();
            usercont.Dispose();
            return usercompList;

        }

    }
}
