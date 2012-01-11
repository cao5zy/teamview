using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;
using System.Transactions;

namespace TeamView.Common.Models
{
    public class KeyModel
    {
        private IBugInfoRepository _repository;
        public KeyModel(IBugInfoRepository repository)
        {
            _repository = repository;
        }

        public string GenerateKey(string keyName)
        {
            keyName = keyName.ToUpper();
            using (TransactionScope trans = new TransactionScope())
            {
                long ? value = _repository.GetCurrentKeyValue(keyName);

                if (value.HasValue)
                {
                    long val = value.Value;
                    _repository.UpdateKeyValue(keyName, ++val);
                    return keyName + "-" + val.ToString();
                }
                else
                {
                    _repository.InsertKeyValue(keyName, 1);
                    return keyName + "-1";
                }
            }
        }
    }
}
