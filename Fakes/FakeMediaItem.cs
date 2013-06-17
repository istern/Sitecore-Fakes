using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Fakes.Fields;

namespace Sitecore.Fakes
{
    public class FakeMediaItem : MediaItem
    {
        private readonly MediaStandardFields _mediaStandardFields;


        public FakeMediaItem(string name = "" ,string filepath="", string alt="", string width="",string height="",string title="",string keywords="",string extension="",string mimetype="",string size="" ) : 
            base(CreateDataItem(name,filepath,alt,width,height,title,keywords,extension,mimetype,size))
        {
            _mediaStandardFields = new MediaStandardFields();
        }

        private static Item CreateDataItem(string name,string filepath, string alt, string width, string height, string title, string keywords, string extension, string mimetype, string size)
        {
            FieldList fieldList = CreateFieldList(filepath, alt, width, height, title, keywords, extension, mimetype, size);
            FakeItem dataItem = new FakeItem(fieldList,name);
            
            
          
            return dataItem;
        }

        private static FieldList CreateFieldList(string filepath, string alt, string width, string height, string title,
                                                      string keywords, string extension, string mimetype, string size)
        {
            FieldList fieldList = new FieldList();

            fieldList.Add(MediaStandardFields.FilePathId, filepath);
            fieldList.Add(MediaStandardFields.AltId, alt);
            fieldList.Add(MediaStandardFields.WidthId, width);
            fieldList.Add(MediaStandardFields.HeightId, height);
            fieldList.Add(MediaStandardFields.TitleId, title);
            fieldList.Add(MediaStandardFields.KeywordsId, keywords);
            fieldList.Add(MediaStandardFields.ExtensionId, extension);
            fieldList.Add(MediaStandardFields.MimetypeId, mimetype);
            fieldList.Add(MediaStandardFields.SizeId, size);
            return fieldList;
        }

       
    }
}
