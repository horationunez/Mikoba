﻿using Hyperledger.Indy.WalletApi;
using System;
using System.IO;
using System.Threading.Tasks;

namespace mikoba
{
    static class WalletUtils
    {
        public static async Task DeleteWalletAsync(string config, string credentials)
        {
            try
            {
                await Wallet.DeleteWalletAsync(config, credentials);
            }
            catch (IOException) //TODO: This should be a more specific error when implemented
            {
                //Swallow expected exception if it happens.
                Console.WriteLine("Wallet Deletion Failed");
            }
        }

    }
}
