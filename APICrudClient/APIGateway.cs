using APICrudClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace APICrudClient
{
    public class APIGateway
    {
        private string url = "https://localhost:7140/api/Customer";
        private HttpClient httpClient = new HttpClient();

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Customer>>(result);
                    if (datacol != null)

                        customers = datacol;
                }
                else
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured Api End point" + result);
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the end point"+ ex.Message);
            }
            finally
            {

            }
            return customers;
        }


        public Customer GetCustomer(int id)
        {
            Customer customers = new Customer();
            url = url + "/" + id;
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<Customer>(result);
                    if (datacol != null)

                        customers = datacol;
                }
                else
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured Api End point" + result);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the end point" + ex.Message);
            }
            finally
            {

            }
            return customers;
        }
        public void UpdateCustomer(Customer customer)
        {
            
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int id = customer.id;

            url = url + "/" + id;
            string json = JsonConvert.SerializeObject(customer);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the end point" + ex.Message);
            }
            finally { }
            return;
        }
        public void DeleteCustomer(int id)
        {

            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            url = url + "/" + id;
            
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the end point" + ex.Message);
            }
            finally { }
            return;
        }


        public Customer CreateCustomers(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(customer);
            try
            {
                HttpResponseMessage responseMessage = httpClient.PostAsync(url,new StringContent(json, Encoding.UTF8,"application/json")).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Customer>(result);
                    if (data != null)
                        customer = data;
                }
                else
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured Api End point" + result);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the end point" + ex.Message);
            }
            finally
            {

            }
            return customer;
        }

    }
}
