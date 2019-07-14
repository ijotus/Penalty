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

        private IPersonalAccountData _accountData;

        public IPersonalAccountData AccountData => _accountData;


        public DataProvider() { }

        public void InitializeCase1()
        {
            var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("dd-MM-yyyy") };
            var serializer = new DataContractJsonSerializer(typeof(IPersonalAccountData), settings);
            using (var stream = new FileStream("account_case_1.json", FileMode.Open))
            {
                _accountData = serializer.ReadObject(stream) as IPersonalAccountData;
            }

            var bankRate = 7.5m;
            _bankRate = new BankRate(new IDateAndValue[]{new DateNowAndValue(bankRate) });

            serializer = new DataContractJsonSerializer(typeof(PenaltyRules), settings);
            using (var stream = new FileStream("rules_case_1.json", FileMode.Open))
            {
                _penaltyRules = serializer.ReadObject(stream) as IPenaltyRules;
            }
        }

        public void InitializeCase2()
        {
            var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("dd-MM-yyyy") };
            var serializer = new DataContractJsonSerializer(typeof(PersonalAccountData), settings);
            using (var stream = new FileStream("account_case_2.json", FileMode.Open))
            {
                _accountData = serializer.ReadObject(stream) as IPersonalAccountData;
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

        public void InitializeCase3()
        {
            var settings = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("dd-MM-yyyy") };
            var serializer = new DataContractJsonSerializer(typeof(IPersonalAccountData), settings);
            using (var stream = new FileStream("account_case_2.json", FileMode.Open))
            {
                _accountData = serializer.ReadObject(stream) as IPersonalAccountData;
            }

            serializer = new DataContractJsonSerializer(typeof(BankRate), settings);
            using (var stream = new FileStream("bankRate.json", FileMode.Open))
            {
                _bankRate = serializer.ReadObject(stream) as IBankRate;
            }

            serializer = new DataContractJsonSerializer(typeof(PenaltyRules), settings);
            using (var stream = new FileStream("rules_case_3.json", FileMode.Open))
            {
                _penaltyRules = serializer.ReadObject(stream) as IPenaltyRules;
            }
        }
    }
}
