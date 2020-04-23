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

        public List<dto.SpellSearch> WildcardSearch(string searchTerm)
        {
            List<dto.SpellSearch> results = new List<dto.SpellSearch>();

            var di = new DirectoryInfo(_indexPath);
            var dir = FSDirectory.Open(di);

            if (_indexConfig == null)
                _indexConfig = new IndexWriterConfig(_AppLuceneVersion, _analyzer);

            var writer = new IndexWriter(dir, _indexConfig);
            var searcher = new IndexSearcher(writer.GetReader(applyAllDeletes: true));

            try
            {
                // search name is lower case, to make thing seasier.
                var phrase = new WildcardQuery(new Term("search_name", '*' + searchTerm + '*'));
                var hits = searcher.Search(phrase, 20).ScoreDocs;
                Console.WriteLine(string.Format("log - index found - ({0}) - ", hits.Length));
                foreach (var hit in hits)
                {
                    var foundDoc = searcher.Doc(hit.Doc);
                    Console.WriteLine(string.Format("log - item found-{0} ({1}) - ", foundDoc.Get("name"), foundDoc.Get("id")));
                    results.Add(new dto.SpellSearch(long.Parse(foundDoc.Get("id")), foundDoc.Get("name").ToString()));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                searcher = null;
                writer.Dispose();
                writer = null;
            }

            return results;
        }

    }
}
