using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
   public class PartnersOptions
    {
        public bool AddCompany(PartnersSet newPartner)
        {
            Permisions aa = new Permisions();
            //   aa.PermissionsID = Permissionsp;
            ContabilidadEntities usercont = new ContabilidadEntities();
            try
            {
                usercont.PartnersSet.Add(newPartner);
                usercont.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public PartnersSet[] GetPartners()
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var Partnerslist = (from db in usercont.PartnersSet
                                 select db).ToArray();
            return Partnerslist;



        }

        public PartnersSet[] GetActivePartners()
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var Partnerslist = (from db in usercont.PartnersSet
                                where db.IsActive == true
                                select db).ToArray();
            return Partnerslist;



        }
        public String[] GetActivePartnersItem()
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var Partnerslist = (from db in usercont.PartnersSet
                                where db.IsActive == true
                                select db.PartnerName).ToArray();
            return Partnerslist;



        }


        public PartnersSet GetPartnerbyID(int id)
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var PartnersList = (from db in usercont.PartnersSet
                            where db.PartnerId == id
                            select db).ToArray()[0];

            return PartnersList;



        }

        public PartnersSet [] GetPartnerServices(int ServiceId)
        {

            ContabilidadEntities usercont = new ContabilidadEntities();

            var PartnersList = (from db in usercont.PartnersServices
                                where db.ServiceId == ServiceId
                                select db.PartnersSet);

            return PartnersList.ToArray();



        }

    }
}
