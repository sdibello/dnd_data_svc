using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene;
using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Directory = Lucene.Net.Store.Directory;
using Lucene.Net.QueryParsers.Classic;
using System.IO;

namespace dnd_graphql_svc.Search
{
    public class Search
    {
        const LuceneVersion _AppLuceneVersion = Lucene.Net.Util.LuceneVersion.LUCENE_48;
        const String _indexPath = @"C:\Index\";
        
        StandardAnalyzer _analyzer = new StandardAnalyzer(_AppLuceneVersion);
        IndexWriterConfig _indexConfig = null;
        IndexWriter _writer = null;


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

        public List<KeyValuePair<long, string>> WildcardSearch(string searchTerm)
        {
            List<KeyValuePair<long, string>> results = new List<KeyValuePair<long, string>>();

            var di = new DirectoryInfo(_indexPath);
            var dir = FSDirectory.Open(di);

            if (_indexConfig == null)
                _indexConfig = new IndexWriterConfig(_AppLuceneVersion, _analyzer);

            if (_writer == null)
                _writer = new IndexWriter(dir, _indexConfig);

            var searcher = new IndexSearcher(_writer.GetReader(applyAllDeletes: true));
            var phrase = new WildcardQuery(new Term("name", '*' + searchTerm + '*'));

            var hits = searcher.Search(phrase, 20).ScoreDocs;
            Console.WriteLine(string.Format("log - index found - ({0}) - ", hits.Length));
            foreach (var hit in hits) {
                var foundDoc = searcher.Doc(hit.Doc);
                Console.WriteLine(string.Format("log - item found-{0} ({1}) - ", foundDoc.Get("name"), foundDoc.Get("id")));
                results.Add(new KeyValuePair<long, string>(long.Parse(foundDoc.Get("id")), foundDoc.Get("name").ToString()));
            }

            return results;
        }

    }
}
