using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using PenaltyCalculations.Model;

namespace PenaltyCalculations
{
    class DataProvider : IPenaltyRulesProvider , IBankRateProvider , IAccountProvider
    {
        private IPenaltyRules _penaltyRules;
        public IPenaltyRules PenaltyRules => _penaltyRules;

        private IBankRate _bankRate;

        public IBankRate BankRate => _bankRate;

        private IPersonalAccount _account;

        public IPersonalAccount Account => _account;


        public DataProvider() { }

        public void InitializeCase0()
        {
            var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("dd-MM-yyyy") };
            var serializer = new DataContractJsonSerializer(typeof(PersonalAccount), settings);
            using (var stream = new FileStream("account.json", FileMode.Open))
            {
                _account = serializer.ReadObject(stream) as PersonalAccount;
            }

            var bankRate = 7.5m;
            _bankRate = new BankRate(new IDateAndValue[]{new DateNowAndValue(bankRate) });

            serializer = new DataContractJsonSerializer(typeof(PenaltyRules), settings);
            using (var stream = new FileStream("rules.json", FileMode.Open))
            {
                _penaltyRules = serializer.ReadObject(stream) as IPenaltyRules;
            }
        }

        public void InitializeCase1()
        {
            var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("dd-MM-yyyy") };
            var serializer = new DataContractJsonSerializer(typeof(PersonalAccount), settings);
            using (var stream = new FileStream("account.json", FileMode.Open))
            {
                _account = serializer.ReadObject(stream) as PersonalAccount;
            }

            serializer = new DataContractJsonSerializer(typeof(BankRate), settings);
            using (var stream = new FileStream("bankRate.json", FileMode.Open))
            {
                _bankRate = serializer.ReadObject(stream) as IBankRate;
            }

            serializer = new DataContractJsonSerializer(typeof(PenaltyRules), settings);
            using (var stream = new FileStream("rules.json", FileMode.Open))
            {
                _penaltyRules = serializer.ReadObject(stream) as IPenaltyRules;
            }
        }

        public void InitializeCase2()
        {
            var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("dd-MM-yyyy") };
            var serializer = new DataContractJsonSerializer(typeof(PersonalAccount), settings);
            using (var stream = new FileStream("account.json", FileMode.Open))
            {
                _account = serializer.ReadObject(stream) as PersonalAccount;
            }

            using (var stream = new FileStream("bankRate.json", FileMode.Open))
            {
                _bankRate = serializer.ReadObject(stream) as IBankRate;
            }

            using (var stream = new FileStream("rules.json", FileMode.Open))
            {
                _penaltyRules = serializer.ReadObject(stream) as IPenaltyRules;
            }
        }
    }
}
