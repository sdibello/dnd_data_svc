using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene;
using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;

namespace dnd_graphql_svc.Search
{
    public class Search
    {
        public void Load()
        {
            // Ensures index backwards compatibility
            var AppLuceneVersion = LuceneVersion.LUCENE_48;

            var indexLocation = @"D:\git\dnd_graphQL_svc\dnd_graphql_svc\Search\index\";
            var dir = FSDirectory.Open(indexLocation);

            //create an analyzer to process the text
            var analyzer = new StandardAnalyzer(AppLuceneVersion);

            //create an index writer
            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            var writer = new IndexWriter(dir, indexConfig);
        }

    }
}
