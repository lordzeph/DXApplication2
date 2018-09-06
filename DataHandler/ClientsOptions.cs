using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    
    public class ClientsOptions
    {
        
        public bool AddClient(ClientsSet newClient)
        {
            Permisions aa = new Permisions();
            //   aa.PermissionsID = Permissionsp;
            ContabilidadEntities usercont = new ContabilidadEntities();
            try
            {
                usercont.ClientsSet.Add(newClient);
                usercont.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public ClientsSet[] GetClients()
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var Partnerslist = (from db in usercont.ClientsSet
                                 select db).ToArray();
            return Partnerslist;



        }

        public ClientsSet[] GetActiveClients()
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var Clientslist = (from db in usercont.ClientsSet
                                where db.IsActive == true
                                select db).ToArray();
            return Clientslist;



        }


        public ClientsSet GetClientbyID(int id)
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var Client = (from db in usercont.ClientsSet
                            where db.ClientId == id
                            select db).Single();

            return Client;



        }

    }
}
