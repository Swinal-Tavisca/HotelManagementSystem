using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelAPI.Models;

namespace HotelAPI.Controllers
{
    public class ProductController : ApiController
    {
        private static List<HotelModel> _hotelList=new List<HotelModel>()
        {
            new HotelModel { Id = 1, Name = "Hayat", NumberOfAvailableRooms = 2, Address = "viman nagar" , CityCode=101},
            new HotelModel { Id = 2, Name = "Blue", NumberOfAvailableRooms = 3, Address = "viman nagar" ,CityCode=102},
            new HotelModel { Id = 3, Name = "hammer", NumberOfAvailableRooms = 3, Address =  "viman nagar" ,CityCode=103},
             new HotelModel { Id = 4, Name = "Radisson", NumberOfAvailableRooms = 10, Address =  "viman nagar" ,CityCode=104}
        };

        

        public APIResponse GetAllHotels()
        {
           // return HotelModel;
            try
            {
                return new APIResponse()
                {
                    hotels = _hotelList,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        ErrorMessage = "ALL HOTELS",
                        ErrorCode = 200
                    }
                };
            }
            catch(Exception e)
            {
                return new APIResponse()
                {
                    hotels = null,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        ErrorCode = 500,
                        ErrorMessage = "SERVER ERROR !"
                    }
                };
            }
        }

       public APIResponse GetHotel(int id)
        {
            var _ifHotelIdPresent = _hotelList.FirstOrDefault((p) => p.Id == id);
            try
            {
                return new APIResponse()
                {
                    hotels = new List<HotelModel>() { _ifHotelIdPresent},
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        ErrorMessage = "HOTEL FOUND !",
                        ErrorCode = 200
                    }
                };
            }
            catch (Exception e)
            {
                return new APIResponse()
                {
                    hotels = null,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        ErrorCode = 500,
                        ErrorMessage = "HOTEL NOT FOUND !"
                    }
                };
            }
        }
        public APIResponse deleteHotel(int id)
        {
            if (_hotelList.Remove(_hotelList.Find(x => x.Id == id)) != false)
            {
                return new APIResponse
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        ErrorMessage = "DATA DELETED !",
                        ErrorCode = 200
                    }
                };
            }
            else
            {
                return new APIResponse
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        ErrorCode = 500,
                        ErrorMessage = "ERROR IN DELETING "
                    }
                };

            }

        }
        public APIResponse PutHotelData(int id, [FromBody] int booking)
        {
            
                if (_hotelList.Find(x => x.Id == id) != null && _hotelList.Find(x => x.Id == id).NumberOfAvailableRooms >= booking && _hotelList.Find(x => x.Id == id).NumberOfAvailableRooms != 0)
                {
                    _hotelList.Find(x => x.Id == id).NumberOfAvailableRooms = _hotelList.Find(x => x.Id == id).NumberOfAvailableRooms - booking;
                    return new APIResponse
                    {
                        Status = new Status()
                        {
                            ApiStatus = ApiStatus.Success,
                            ErrorMessage = "DATA UPDATED",
                            ErrorCode = 200
                        }
                    };
                }
                else
                {
                    return new APIResponse
                    {
                        Status = new Status()
                        {
                             ApiStatus = ApiStatus.Success,
                            ErrorMessage = "ERROR IN UPDATING DATA",
                            ErrorCode = 200
                        }
                    };
                }
            
        }
        public APIResponse PostHotelData(HotelModel addHotel)
        {
            if (_hotelList.Find(x => x.Id == addHotel.Id) == null)
            {
                _hotelList.Add(addHotel);
                return new APIResponse
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        ErrorMessage = "UPDATED DATA",
                        ErrorCode = 200
                    }

                };
            }
            else
            {
                return new APIResponse
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        ErrorMessage = "ERROR IN UPDATING DATA",
                        ErrorCode = 200
                    }
                };
            }
        }



    }
}
