using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
   public class OperationsOptionscs
    {
        ContabilidadEntities usercont;
        public String[] GetServicesTypes()
        {
            usercont = new ContabilidadEntities();

            var servicetypes = (from db in usercont.ServiceTypes
                                select db.ServiceType).ToArray();
            return servicetypes;


                               
        }

        public int GetServiceID(string name)
        {
            usercont = new ContabilidadEntities();

            var serviceid = (from db in usercont.ServicesSet
                                where db.Servicename == name
                                select db.ServiceId).ToArray().Last();
            return serviceid;



        }

        public ClientsServices GetPayerclient(int serviceid)
        {
            ClientsServices payert = new ClientsServices();
            try
            {
    usercont = new ContabilidadEntities();

            payert = (from db in usercont.ClientsServices
                               where db.ServiceId == serviceid & db.IsPayer == true
                               
                             select db).ToArray().Single();
            return payert;
            }
            catch (Exception ex)
            {

                return payert;
            }
           



        }

        public ClientsSet GetuserService(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var payerClient = (from db in usercont.ClientsServices
                               where db.ServiceId == serviceid & db.IsPayer == true
                               
                               select db.ClientsSet).ToArray().Single();
            return payerClient;



        }

        public ClientsServices [] GetTouristClients(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var payerClient = (from db in usercont.ClientsServices
                               where db.ServiceId == serviceid & db.IsPayer == false
                               
                               select db).ToArray();
            return payerClient;



        }

        public PartnersServices[] GetServicePartners(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var partners = (from db in usercont.PartnersServices
                               where db.ServiceId == serviceid
                               
                               select db).ToArray();
            return partners;
        }

        public int GetServicePartnerID(int partnerid,int serviceid)
        {
            usercont = new ContabilidadEntities();

            var partners = (from db in usercont.PartnersServices
                            where db.PartnerId == partnerid & db.ServiceId == serviceid
                            
                            select db.PartnersServicesID).Single();
            return partners;
        }

        public int GetServicePartnerID(string partnername, int serviceid)
        {
            usercont = new ContabilidadEntities();

            var partners = (from db in usercont.PartnersServices
                            where db.PartnersSet.PartnerName == partnername
                            & db.ServiceId == serviceid
                            select db.PartnersServicesID).Single();
            return partners;
        }


        public ClientsServices[] GetClientsServices(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var clients = (from db in usercont.ClientsServices
                            where db.ServiceId == serviceid

                            select db).ToArray();
            return clients;



        }

        public AirTicketsSet[] GetPlanedata(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var airtickets = (from db in usercont.AirTicketsSet
                           where db.PartnersServices.ServiceId == serviceid

                           select db).ToArray();
            return airtickets;



        }

        public TrainTicketsSet[] Gettraindata(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var traintickets = (from db in usercont.TrainTicketsSet
                              where db.PartnersServices.ServiceId == serviceid

                              select db).ToArray();
            return traintickets;



        }

        public TransferSet[] Gettransferdata(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var transfers = (from db in usercont.TransferSet
                              where db.PartnersServices.ServiceId == serviceid

                              select db).ToArray();
            return transfers;



        }

        public ToursSet[] Getexcursiondata(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var excursions = (from db in usercont.ToursSet
                             where db.PartnersServices.ServiceId == serviceid

                             select db).ToArray();
            return excursions ;



        }

        public HotelsSet[] GetHotelsdata(int serviceid)
        {
            usercont = new ContabilidadEntities();

            var hotels = (from db in usercont.HotelsSet
                              where db.PartnersServices.ServiceId == serviceid

                              select db).ToArray();
            return hotels;



        }

        public int GetServicesTypeId(string servicetype)
        {
            usercont = new ContabilidadEntities();

            var servicetypes = (from db in usercont.ServiceTypes
                                where db.ServiceType == servicetype
                                select db.ServiceTypeID).ToArray()[0];
            
                                
            return servicetypes;



        }

        public ServicesSet[] GetServices(DateTime fromD , DateTime toD)
        {
            usercont = new ContabilidadEntities();

            var servicetypes = (from db in usercont.ServicesSet
                                where db.CreationDate >= fromD
                                & db.CreationDate <= toD
                                select db).ToArray();


            return servicetypes;



        }

        public ServicesSet[] GetServices(DateTime fromD, DateTime toD,int userid)
        {
            usercont = new ContabilidadEntities();

            var servicetypes = (from db in usercont.ServicesSet
                                where db.CreationDate >= fromD
                                & db.CreationDate <= toD
                                & db.UserId == userid
                                select db).ToArray();


            return servicetypes;



        }

        public String[] GetCountries()
        {
            usercont = new ContabilidadEntities();

            var Countries = (from db in usercont.CountriesSet
                                select db.CountryName).ToArray();
            return Countries;



        }

        public int GetCountrybyName(string cname)
        {
            usercont = new ContabilidadEntities();

            var Countries = (from db in usercont.CountriesSet
                             where db.CountryName == cname
                             select db.CountryId).Single();
            return Countries;



        }

        public void UpdateService(ServicesSet oldvalue, ServicesSet newvalue)
        {
            usercont = new ContabilidadEntities();
            //newvalue.ClientsServices = null;
            //newvalue.CompaniesSet = null;
            //newvalue.CountriesSet = null;
            //newvalue.ExpensesSet = null;
            //newvalue.PartnersServices = null;
            //newvalue.ServiceTypes = null;
            //newvalue.Users = null;

            usercont.ServicesSet.Attach(oldvalue);
            

            usercont.Entry(oldvalue).CurrentValues.SetValues(newvalue);
            usercont.SaveChanges();
            usercont.Dispose();
           
        }

        public PartnersSet getparner(string PartnerName)
        {
            usercont = new ContabilidadEntities();
            PartnersSet partser = (from db in usercont.PartnersSet
                                        where db.PartnerName == PartnerName
                                        
                                        select db).ToArray()[0];
           // selecoper.PartnersServices.Add(new PartnersServices() { PartnerId = partser.PartnerId, PartnersSet = partser });

           // usercont.ServicesSet.Add(selecoper);
          //  usercont.SaveChanges();
            return partser;



        }


        public void UpdateClientsServices(int serviceid, ClientsServices[] newclientlist)
        {
            usercont = new ContabilidadEntities();
           ClientsServices [] todelete = GetClientsServices(serviceid);
            for (int i = 0; i < todelete.Length; i++)
            {
                usercont.ClientsServices.Attach(todelete[i]);
                usercont.ClientsServices.Remove(todelete[i]);
            }

            //usercont.ClientsServices.RemoveRange(GetClientsServices(serviceid));
            for (int i = 0; i < newclientlist.Length; i++)
            {
                ClientsServices toadd = new ClientsServices()
                {
                    Clientid = newclientlist[i].Clientid,
                ServiceId = serviceid,
                IsPayer = newclientlist[i].IsPayer


                };
                usercont.ClientsServices.Add(toadd);
            }
           // usercont.ClientsServices.AddRange(newclientlist);
            usercont.SaveChanges();
            usercont.Dispose();

        }
        public void UpdatepartnersServices(int serviceid, PartnersServices[] newpartnerlist)
        {
            

            usercont = new ContabilidadEntities();

            PartnersServices [] todelete = GetServicePartners(serviceid);
            for (int i = 0; i < todelete.Length; i++)
            {
                usercont.PartnersServices.Attach(todelete[i]);
                usercont.PartnersServices.Remove(todelete[i]);
            }
            for (int i = 0; i < newpartnerlist.Length; i++)
            {
                PartnersServices toadd = new PartnersServices()
                {
                    PartnerId = newpartnerlist[i].PartnerId,
                    ServiceId = newpartnerlist[i].ServiceId

                };
                usercont.PartnersServices.Add(toadd);
            }
          //  usercont.PartnersServices.RemoveRange(GetServicePartners(serviceid));
          //  usercont.PartnersServices.AddRange(newpartnerlist);
            usercont.SaveChanges();
            usercont.Dispose();


        }


        public void addclientService(int clientid, int serviceid,bool ispayer)
        {
            usercont = new ContabilidadEntities();
            usercont.ClientsServices.Add(new ClientsServices() { Clientid = clientid, ServiceId = serviceid, IsPayer=ispayer });
            usercont.SaveChanges();
            usercont.Dispose();

        }

        public void RemoveclientService(string clientname)
        {
            usercont = new ContabilidadEntities();
            //usercont.ClientsServices.;
            usercont.SaveChanges();
            usercont.Dispose();

        }

        public void addPartnerService(int serviceid,int partnerid)
        {
            usercont = new ContabilidadEntities();
            usercont.PartnersServices.Add(new PartnersServices { PartnerId = partnerid, ServiceId = serviceid });
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void addOperation(ServicesSet operation)
        {
            usercont = new ContabilidadEntities();
            usercont.ServicesSet.Add(operation);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void addPlaneticket(AirTicketsSet planeticket)
        {
            usercont = new ContabilidadEntities();
            usercont.AirTicketsSet.Add(planeticket);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void UpdatePlaneticket(AirTicketsSet oldplaneticket,AirTicketsSet newplanetickets)
        {
            usercont = new ContabilidadEntities();
           usercont.AirTicketsSet.Attach(oldplaneticket);
            usercont.Entry(oldplaneticket).CurrentValues.SetValues(newplanetickets);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void UpdateTrainticket(TrainTicketsSet oldtrainticket, TrainTicketsSet newtrainticket)
        {
            usercont = new ContabilidadEntities();
            usercont.TrainTicketsSet.Attach(oldtrainticket);
            usercont.Entry(oldtrainticket).CurrentValues.SetValues(newtrainticket);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void Updatetransfer(TransferSet oldtransfer, TransferSet newtransfer)
        {
            usercont = new ContabilidadEntities();
            usercont.TransferSet.Attach(oldtransfer);
            usercont.Entry(oldtransfer).CurrentValues.SetValues(newtransfer);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void UpdateTour(ToursSet oldtour, ToursSet newtour)
        {
            usercont = new ContabilidadEntities();
            usercont.ToursSet.Attach(oldtour);
            usercont.Entry(oldtour).CurrentValues.SetValues(newtour);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void UpdateHotels(HotelsSet oldhotel, HotelsSet newhotel)
        { 
            usercont = new ContabilidadEntities();
            usercont.HotelsSet.Attach(oldhotel);
            usercont.Entry(oldhotel).CurrentValues.SetValues(newhotel);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void addTour(ToursSet tour)
        {
            usercont = new ContabilidadEntities();
            usercont.ToursSet.Add(tour);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void addTrain(TrainTicketsSet train)
        {
            usercont = new ContabilidadEntities();
            usercont.TrainTicketsSet.Add(train);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void addTransfer(TransferSet transfer)
        {
            usercont = new ContabilidadEntities();
            usercont.TransferSet.Add(transfer);
            usercont.SaveChanges();
            usercont.Dispose();


        }

        public void addHotel(HotelsSet hotel)
        {
            usercont = new ContabilidadEntities();
            usercont.HotelsSet.Add(hotel);
            usercont.SaveChanges();
            usercont.Dispose();


        }



    }
}
