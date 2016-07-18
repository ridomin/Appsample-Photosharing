//-----------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using System.Web.Configuration;

namespace PhotoSharingApp.AppService.Shared.Context
{
    /// <summary>
    /// The service environment definition.
    /// </summary>
    public class EnvironmentDefinition : EnvironmentDefinitionBase
    {
        private DocumentDbStorage _documentDbStorage;

        /// <summary>
        /// The DocumentDB database.
        /// </summary>
        public override DocumentDbStorage DocumentDbStorage
        {
            get
            {
                if (_documentDbStorage == null)
                {
                    _documentDbStorage = new DocumentDbStorage
                    {
                        // We have supplied a default DatabaseId and CollectionId here, feel free to configure your own.
                        // On first time startup, the service will create a DocumentDB database and collection for you
                        // if none exist with these names.
                        DataBaseId = "photosharing-database",
                        CollectionId = "photosharing-document-data",
                        EndpointUrl = "https://ridophotos.documents.azure.com:443/",
                        AuthorizationKey = "poZUfiYj6kq4P0YKaw1djfxRIll9kXy494xv1JS6KW5FTm0duFinBeUX6rx8Dyf34NgtjZEIhiAPYlQISKny9w=="
                    };
                }

                return _documentDbStorage;
            }
        }

        /// <summary>
        /// The Notification Hub's default full shared access signature.
        /// </summary>
        public override string HubFullSharedAccessSignature
        {
            get
            {
                return "Endpoint=sb://ridophotos.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=yID9xouRNrDeLYwCuSFFzdZF0jqK4lThEfknE4bH7Fg=";
            }
        }

        /// <summary>
        /// The Notification Hub's name.
        /// </summary>
        public override string HubName
        {
            get { return "ridophotos"; }
        }

        /// <summary>
        /// The Application Insights instrumentation key. This value is read from the Web.config file.
        /// </summary>
        public override string InstrumentationKey
        {
            get { return "bdac1257-9b70-4e98-9f9d-f4230c7798f4"; }
        }

        /// <summary>
        /// The Azure Storage access key that is used for storing
        /// uploaded photos.
        /// </summary>
        public override string StorageAccessKey
        {
            get { return "6ShD2OCBNhuoDZYKBASCrC9mQqEP7JzrkoVYNz20ptevYWrlirJ28a2s+Fk2UQWTepgQr8K6ZUa82LFiWwAyYA=="; }
        }

        /// <summary>
        /// The Azure Storage account name that is used for storing
        /// uploaded photos.
        /// </summary>
        public override string StorageAccountName
        {
            get { return "ridophotos"; }
        }
    }
}