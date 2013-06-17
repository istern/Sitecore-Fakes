using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Fakes.Fields;

namespace Sitecore.Fakes
{
    public class FakeMediaItem : MediaItem
    {

        public FakeMediaItem(string name = "" ,string filepath="", string alt="", string width="",string height="",string title="",string keywords="",string extension="",string mimetype="",string size="" ) : 
            base(CreateDataItem(name,filepath,alt,width,height,title,keywords,extension,mimetype,size))
        {
          
        }

        private static Item CreateDataItem(string name,string filepath, string alt, string width, string height, string title, string keywords, string extension, string mimetype, string size)
        {
            FieldList fieldList = CreateFieldList(filepath, alt, width, height, title, keywords, extension, mimetype, size);
            var dataItem = new FakeItem(fieldList,name);
            
            
          
            return dataItem;
        }

        private static FieldList CreateFieldList(string filepath, string alt, string width, string height, string title,
                                                      string keywords, string extension, string mimetype, string size)
        {
            var fieldList = new FieldList
                {
                    {MediaStandardFields.FilePathId, filepath},
                    {MediaStandardFields.AltId, alt},
                    {MediaStandardFields.WidthId, width},
                    {MediaStandardFields.HeightId, height},
                    {MediaStandardFields.TitleId, title},
                    {MediaStandardFields.KeywordsId, keywords},
                    {MediaStandardFields.ExtensionId, extension},
                    {MediaStandardFields.MimetypeId, mimetype},
                    {MediaStandardFields.SizeId, size}
                };

            return fieldList;
        }

       
    }
}
