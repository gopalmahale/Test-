using Microsoft.SharePoint.Client;
using SKP.SharepointOnlineHelper.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sennit.SharepointAutoMapper;
using SKP.Gama.BO;
using System.Reflection;
using System.IO;

namespace SKP.SharepointOnlineHelper.Helper
{
    public class SharepointList
    {

        public MsOnlineClaimsHelper claimsHelper;
        public string UrlApp;
        protected SharepointList() { }

        /// <summary>
        /// Instantiation
        /// </summary>
        /// <param name="Auth"></param>
        public SharepointList(SharepointAuth Auth)
        {
            claimsHelper = new MsOnlineClaimsHelper(Auth.UrlApp, Auth.SPUserName, Auth.SPPassword);
            UrlApp = Auth.UrlApp;
        }

        #region Functions to get data from SharePoint

        /// <summary>
        /// Get all the list items from provided list
        /// </summary>
        /// <typeparam name="T">Provide SharePoint list object entity class</typeparam>
        /// <returns></returns>
        public ListItemCollection GetAll<T>() where T : IEntitySharepointMapper
        {

            using (ClientContext context = new ClientContext(UrlApp))
            {
                T entity = (T)Activator.CreateInstance(typeof(T));

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                List allergiesList = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                CamlQuery query = CamlQuery.CreateAllItemsQuery();

                ListItemCollection items = allergiesList.GetItems(query);

                context.Load(items);
                context.ExecuteQuery();

                return items;
            }

        }

        /// <summary>
        /// Get the list item by ID
        /// </summary>
        /// <param name="ListName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ListItemCollection GetById<T>(Int16 Id) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                T entity = (T)Activator.CreateInstance(typeof(T));

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                List allergiesList = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                CamlQuery query = new CamlQuery();

                query.ViewXml = GetCamlQueryById(Id.ToString());

                ListItemCollection items = allergiesList.GetItems(query);

                context.Load(items);
                context.ExecuteQuery();

                return items;

            }
        }

        /// <summary>
        /// get by id or camal query
        /// </summary>
        /// <param name="ListName"></param>
        /// <param name="Query"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ListItemCollection Get(string ListName, string Query, Int32? Id)
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                List allergiesList = context.Web.Lists.GetByTitle(ListName);

                //context.Load(allergiesList);
                //context5.ExecuteQuery();

                CamlQuery query = new CamlQuery() { ViewXml = Query };

                if (Id.HasValue)
                    query.ViewXml = GetCamlQueryById(Id.Value.ToString());

                else if (string.IsNullOrEmpty(Query))
                    query = CamlQuery.CreateAllItemsQuery();

                ListItemCollection items = allergiesList.GetItems(query);

                context.Load(items);
                context.ExecuteQuery();

                return items;

            }
        }
         

        /// <summary>
        /// Actual function to retrive data from SharePoint by ID or CAML Query
        /// </summary>
        /// <param name="ListName">Name of the list</param>
        /// <param name="Query">CAML Query to retrive data</param>
        /// <param name="Id">List item id</param>
        /// <returns></returns>
        public ListItemCollection Get<T>(string Query) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                T entity = (T)Activator.CreateInstance(typeof(T));

                // Build ViewList for CAML query

                //#region Check if needs to apply ViewFields in CAML

                ////var o = typeof(T).GetCustomAttributes(typeof(IgnoreInCAMLRestriction), true);

                ////IgnoreInCAMLRestriction camlRestriction = typeof(T).GetCustomAttributes(typeof(IgnoreInCAMLRestriction), true)[0] as IgnoreInCAMLRestriction;

                //if(typeof(T).GetCustomAttributes(typeof(IgnoreInCAMLRestriction), true).Count() == 0)
                //{
                //    string LookupFields = "";
                //    string OtherFields = "";

                //    //foreach (PropertyInfo property in typeof(T).GetProperties())
                //    //{

                //    //    IEnumerable<CustomAttributeData> cData = property.CustomAttributes;

                //    //    if (cData.Count() > 0)
                //    //    {
                //    //        if (cData.Where(t => t.AttributeType.Name == "SharepointFieldName").Count() > 0)
                //    //        {
                //    //            //string name = typeof(MyClass).GetAttributeValue((DomainNameAttribute dna) => dna.Name);

                //    //        }
                //    //        else if (cData.Where(t => t.AttributeType.Name == "SharepointFieldName").Count() > 0)
                //    //        {
                //    //            //string name = typeof(MyClass).GetAttributeValue((DomainNameAttribute dna) => dna.Name);

                //    //        }
                //    //    }

                //    //}


                //    PropertyInfo[] props = typeof(T).GetProperties();
                //    foreach (PropertyInfo prop in props)
                //    {
                //        string FieldName = "";
                //        bool CanAdd = true;
                //        object[] attrs = prop.GetCustomAttributes(true);
                //        foreach (object attr in attrs)
                //        {
                //            SharepointFieldName authAttr = attr as SharepointFieldName;
                //            if (authAttr != null)
                //            {
                //                string propName = prop.Name;
                //                FieldName = authAttr.name;
                //            }
                //            else
                //            {
                //                IgnoreInOperation a = attr as IgnoreInOperation;
                //                if (a != null)
                //                {
                //                    if(a._Operation == "Select")
                //                    {
                //                        CanAdd = false;
                //                        break;
                //                    }                                    
                //                }
                //            }
                //        }

                //        if (CanAdd && FieldName != "")
                //        {
                //            OtherFields = OtherFields + "<FieldRef Name='"+ FieldName +"'/>";
                //        }
                //    }


                //    if(Query.Contains("</ViewFields>") == false && OtherFields != "")
                //    {
                //        OtherFields = "<ViewFields>" + OtherFields + "</ViewFields>";
                //        int i = Query.IndexOf("</View>");
                //        string temp = Query.Substring(0, i).ToString() + OtherFields + Query.Substring(i, Query.Length - i).ToString();
                //        Query = temp;
                //    }

                //}
                
                //#endregion


                context.RequestTimeout = -1;

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                List allergiesList = context.Web.Lists.GetByTitle(entity.GetSharepointListName());
                
                CamlQuery query = new CamlQuery() { ViewXml = Query };
                
                ListItemCollection items = allergiesList.GetItems(query);

                context.Load(items);
                context.ExecuteQuery();

                return items;

            }
        }


        
        /// <summary>
        /// Get List Item ID as per the provided title
        /// </summary>
        /// <param name="ListName">List Name</param>
        /// <param name="Title">Tite to search</param>
        /// <returns></returns>
        public Int16? GetItemIdByTitle<T>(string Title) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                T entity = (T)Activator.CreateInstance(typeof(T));

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                List allergiesList = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                CamlQuery query = new CamlQuery() { ViewXml = "<View><Query><OrderBy><FieldRef Name='Title' Ascending='TRUE'></FieldRef></OrderBy><Where><Eq><FieldRef Name='Title'  ></FieldRef><Value Type='Text'>" + Title + "</Value></Eq></Where></Query></View>" };

                ListItemCollection items = allergiesList.GetItems(query);

                context.Load(items);
                context.ExecuteQuery();

                if (items.Count > 0)
                    return Convert.ToInt16(items[0]["ID"].ToString());
            }

            return null;
        }

        /// <summary>
        /// Get list of Users from SharePoint group
        /// </summary>
        /// <param name="GroupTitle">Group to get the user list</param>
        /// <returns></returns>
        public List<SPUser> GetUsers(string GroupTitle)
        {
            List<SPUser> lstUsers = new List<SPUser>();

            using (ClientContext context = new ClientContext(UrlApp))
            {
                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                Microsoft.SharePoint.Client.GroupCollection grps = context.Web.SiteGroups;
                UserCollection usr = context.Web.SiteUsers;
                
                context.Load(grps, groups => groups.Where(group => group.Title == GroupTitle));
                context.ExecuteQuery(); //LINQ executes here and hits the site to get the data

                if (grps.Count > 0)
                {
                    context.Load(grps[0].Users);
                    context.ExecuteQuery();

                    //spgs = new List<string>();
                    foreach (User oUser in grps[0].Users)
                    {
                        SPUser xUser = new SPUser();
                        xUser.UserID = oUser.Id;
                        xUser.Title = oUser.Title;
                        xUser.UserAccount = oUser.LoginName;
                        lstUsers.Add(xUser);
                    }
                }

            }

            return lstUsers;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupTitle"></param>
        /// <returns></returns>
        public List<LookupFieldMapper> GetLookupUsersFromGroup(string GroupTitle)
        {
            List<LookupFieldMapper> lstUsers = new List<LookupFieldMapper>();

            using (ClientContext context = new ClientContext(UrlApp))
            {
                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                Microsoft.SharePoint.Client.GroupCollection grps = context.Web.SiteGroups;
                UserCollection usr = context.Web.SiteUsers;

                context.Load(grps, groups => groups.Where(group => group.Title == GroupTitle));
                context.ExecuteQuery(); //LINQ executes here and hits the site to get the data

                if (grps.Count > 0)
                {
                    context.Load(grps[0].Users);
                    context.ExecuteQuery();

                    //spgs = new List<string>();
                    foreach (User oUser in grps[0].Users)
                    {
                        LookupFieldMapper xUser = new LookupFieldMapper() { ID = oUser.Id, Value = oUser.Title };
                        lstUsers.Add(xUser);
                    }
                }

            }

            return lstUsers;
        }

        /// <summary>
        /// Get the list of groups of current login user
        /// </summary>
        /// <returns></returns>
        public Microsoft.SharePoint.Client.GroupCollection GetCurrentUserGroups()
        {
            //List<SPGroup> lstGroups = new List<SPGroup>();

            using (ClientContext context = new ClientContext(UrlApp))
            {
                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                //GroupCollection grps = context.Web.SiteGroups;
                //UserCollection usr = context.Web.SiteUsers;
                Microsoft.SharePoint.Client.GroupCollection UserGroups = context.Web.CurrentUser.Groups;

                //context.Load(grps, us=> us.Where(u=> u.) //  groups => groups.Where(group => group.Users.Where(u=> u.LoginName==UserName)));
                context.Load(UserGroups);
                context.ExecuteQuery(); //LINQ executes here and hits the site to get the data

                return UserGroups;
                ////context.Load(grps[0].Users);
                ////context.ExecuteQuery();
                //foreach (Group oGroup in UserGroups)
                //{
                //    SPGroup xGroup = new SPGroup();
                //    xGroup.GroupID = oGroup.Id;
                //    xGroup.Title = oGroup.Title;
                //    lstGroups.Add(xGroup);
                //}
            }
            //return lstGroups;
        }

        #endregion

        #region List and Library CRUD Functions

        #region Custom List Operations

        /// <summary>
        /// Create new line item on SharePoint custom list, without attachment
        /// </summary>
        /// <param name="ListName">Liast name to create item</param>
        /// <param name="propriedades">Proprties to update</param>
        /// <returns></returns>
        public ListItem NewItem(String ListName, Dictionary<String, String> propriedades)
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                Web web = context.Web;


                List lista = web.Lists.GetByTitle(ListName);
                ListItemCreationInformation itemCreationInfo = new ListItemCreationInformation();
                ListItem item = lista.AddItem(itemCreationInfo);

                foreach (KeyValuePair<string, string> itemPropriedades in propriedades)
                    item[itemPropriedades.Key] = itemPropriedades.Value;

                item.Update();
                context.Load<List>(lista);
                context.Load<Microsoft.SharePoint.Client.ListItem>(item);
                context.ExecuteQuery();

                return item;
            }
        }

        /// <summary>
        /// Add item to SharePoint Custom List
        /// </summary>
        /// <typeparam name="T">List type class</typeparam>
        /// <param name="entity">List object</param>
        /// <returns></returns>
        public ListItem NewItem<T>(T entity) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                Web web = context.Web;

                List list = web.Lists.GetByTitle(entity.GetSharepointListName());
                ListItemCreationInformation itemCreationInfo = new ListItemCreationInformation();
                ListItem item = list.AddItem(itemCreationInfo);

                int ItemID = 0;

                try
                {

                    // Add all field values to item                      
                    Dictionary<string, object> lstFields = this.GetListFields(entity, "Insert");

                    foreach (KeyValuePair<string, object> entry in lstFields)
                    {
                        if (entry.Key != "Id" && entry.Key != "Modified" && entry.Key != "Created")
                        {
                            if (entry.Value != null)
                            {

                                // If type is datetime then need to check if it has default date
                                if (entry.Value.GetType() == typeof(DateTime))
                                {
                                    if (((DateTime)entry.Value).ToString("yyyy/MM/dd") != "0001/01/01")
                                        item[entry.Key] = entry.Value;
                                }
                                else if (entry.Value.GetType() == typeof(List<LookupFieldMapper>))
                                {

                                    List<FieldUserValue> users = new List<FieldUserValue>();
                                    List<LookupFieldMapper> listUsers = (List<LookupFieldMapper>)entry.Value;

                                    foreach (LookupFieldMapper user in listUsers)
                                    {
                                        FieldUserValue userValue = new FieldUserValue();
                                        userValue.LookupId = (int)user.ID;
                                        users.Add(userValue);
                                    }

                                    //  uploadFile.ListItemAllFields[entry.Key] = users;
                                    item[entry.Key] = users;
                                }
                                else
                                {
                                    // If field type is lookup mapper then need to assign id only
                                    if (entry.Value.GetType() == typeof(LookupFieldMapper))
                                        item[entry.Key] = ((LookupFieldMapper)entry.Value).ID;
                                    else
                                        item[entry.Key] = entry.Value;
                                }

                            }
                        }
                    }

                    item.Update();
                    context.Load<List>(list);
                    context.Load<Microsoft.SharePoint.Client.ListItem>(item);
                    context.ExecuteQuery();
                    ItemID = item.Id;
                }
                catch (Exception ex)
                {
                    return null;
                }

                return item;
            }
        }

        /// <summary>
        /// Upload provided entry item to SharePoint custom list with attachment
        /// </summary>
        /// <typeparam name="T">Type of entity class</typeparam>
        /// <param name="entity">Actual mapped list Entity</param>
        /// <param name="iStatus">By referance to get the status of the upload</param>
        /// <param name="iError">By reference string variable to get the error if occured</param>
        /// <param name="strFilePath">If want to upload attachment then file path</param>
        /// <returns>List item created on SharePoint</returns>
        /*  public ListItem NewItem<T>(T entity, ref Enums.NewItemStatus iStatus, ref Exception iError, string strFilePath = "") where T : IEntitySharepointMapper
          {

              using (ClientContext context = new ClientContext(UrlApp))
              {
                  iError = null;
                  iStatus = Enums.NewItemStatus.CreatedSucsesfully;

                  context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                  Web web = context.Web;

                  List lista = web.Lists.GetByTitle(entity.GetSharepointListName());
                  ListItemCreationInformation itemCreationInfo = new ListItemCreationInformation();
                  ListItem item = lista.AddItem(itemCreationInfo);

                  int ItemID = 0;

                  try
                  {
                      item.ProjectListItemFromEntity<T>(entity);
                      item.Update();
                      context.Load<List>(lista);
                      context.Load<Microsoft.SharePoint.Client.ListItem>(item);
                      context.ExecuteQuery();
                      ItemID = item.Id;
                  }
                  catch (Exception ex)
                  {
                      SKPLib.SendError(ex, "NewItem");
                      iError = ex;
                      iStatus = Enums.NewItemStatus.FailedInItemCreation;
                      return null;
                  }

                  if (strFilePath != "" && iStatus != Enums.NewItemStatus.FailedInItemCreation)
                  {

                      bool isUploaded = false;
                      for (int i = 0; i < 5; i++)
                      {
                          isUploaded = false;
                          ListItem item2 = UploadAttachment(entity, ItemID, ref iStatus, ref iError, strFilePath);
                          if (iError == null)
                          {
                              isUploaded = true;
                              break;
                          }
                      }

                      if (isUploaded == false)
                      {
                          //this.DeleteItem<T>(entity, ItemID);
                      }

                  }
                  // If no attachment uploaded then return only item created on SharePoint
                  return item;
              }
          }*/
        #endregion

        public ListItem NewItem<T>(T entity, ref Enums.NewItemStatus iStatus, ref Exception iError, string strFilePath = "") where T : IEntitySharepointMapper
        {

            using (ClientContext context = new ClientContext(UrlApp))
            {
                iError = null;
                iStatus = Enums.NewItemStatus.CreatedSucsesfully;

                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                Web web = context.Web;

                List lista = web.Lists.GetByTitle(entity.GetSharepointListName());
                ListItemCreationInformation itemCreationInfo = new ListItemCreationInformation();
                ListItem item = lista.AddItem(itemCreationInfo);

                int ItemID = 0;

                try
                {

                    // Add all field values to item                      
                    Dictionary<string, object> lstFields = this.GetListFields(entity, "Insert");

                    foreach (KeyValuePair<string, object> entry in lstFields)
                    {
                        if (entry.Key != "Id" && entry.Key != "Modified" && entry.Key != "Created")
                        {
                            if (entry.Value != null)
                            {

                                // If type is datetime then need to check if it has default date
                                if (entry.Value.GetType() == typeof(DateTime))
                                {
                                    if (((DateTime)entry.Value).ToString("yyyy/MM/dd") != "0001/01/01")
                                        item[entry.Key] = entry.Value;
                                }
                                else if (entry.Value.GetType() == typeof(List<LookupFieldMapper>))
                                {                                    
                                    List<FieldUserValue> users = new List<FieldUserValue>();
                                    List<LookupFieldMapper> listUsers = (List<LookupFieldMapper>)entry.Value;

                                    foreach (LookupFieldMapper user in listUsers)
                                    {
                                        FieldUserValue userValue = new FieldUserValue();
                                        userValue.LookupId = (int)user.ID;
                                        users.Add(userValue);
                                    }

                                    //  uploadFile.ListItemAllFields[entry.Key] = users;
                                    item[entry.Key] = users;
                                }
                                else
                                {
                                    // If field type is lookup mapper then need to assign id only
                                    if (entry.Value.GetType() == typeof(LookupFieldMapper))
                                        item[entry.Key] = ((LookupFieldMapper)entry.Value).ID;
                                    else
                                        item[entry.Key] = entry.Value;
                                }

                            }
                        }
                    }

                    item.Update();
                    context.Load<List>(lista);
                    context.Load<Microsoft.SharePoint.Client.ListItem>(item);
                    context.ExecuteQuery();
                    ItemID = item.Id;
                }
                catch (Exception ex)
                {
                    return null;
                }

                //return item;

                if (strFilePath != "" && iStatus != Enums.NewItemStatus.FailedInItemCreation)
                {

                    bool isUploaded = false;
                    for (int i = 0; i < 5; i++)
                    {
                        isUploaded = false;
                        ListItem item2 = UploadAttachment(entity, ItemID, ref iStatus, ref iError, strFilePath);
                        if (iError == null)
                        {
                            isUploaded = true;
                            break;
                        }
                    }

                    if (isUploaded == false)
                    {
                        //this.DeleteItem<T>(entity, ItemID);
                    }

                }
                // If no attachment uploaded then return only item created on SharePoint
                return item;
            }
        }
         

        /// <summary>
        /// Delete SharePoint list or library item by ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteItem<T>(int ID) where T : IEntitySharepointMapper
        {

            try
            {

                using (ClientContext context = new ClientContext(UrlApp))
                {

                    T entity = (T)Activator.CreateInstance(typeof(T));

                    // Setting Client Context for the Upload operation
                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web = context.Web;

                    // Get document library
                    List lista = web.Lists.GetByTitle(entity.GetSharepointListName());

                    ListItem item = lista.GetItemById(ID);
                    context.Load(item);
                    context.ExecuteQuery();

                    item.DeleteObject();
                    context.ExecuteQuery();

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Delete all the items by caml query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="camlQuery"></param>
        /// <returns>Number of items deleted. In case of error -1 returned.</returns>
        public int DeleteItemsBulk<T>(string camlQuery) where T : IEntitySharepointMapper
        {

            try
            {
                int count = 0;
                using (ClientContext context = new ClientContext(UrlApp))
                {
                    T entity = (T)Activator.CreateInstance(typeof(T));

                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                    List allergiesList = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                    CamlQuery query = new CamlQuery() { ViewXml = camlQuery };

                    // Get the list of items as per query
                    ListItemCollection items = allergiesList.GetItems(query);

                    context.Load(items);
                    context.ExecuteQuery();

                    // Remove all the selected items 
                    foreach (ListItem item in items.ToList())
                    {
                        item.DeleteObject();
                        count++;
                    }

                    context.ExecuteQuery();

                }

                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        public ListItem UpdateItem<T>(T entity) where T : IEntitySharepointMapper
        {

            try
            {
                using (ClientContext context = new ClientContext(UrlApp))
                {
                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web = context.Web;

                    List lista = web.Lists.GetByTitle(entity.GetSharepointListName());
                    ListItem item = lista.GetItemById(entity.GetIdFromEntity());

                    context.Load(item);
                    context.ExecuteQuery();

                    Dictionary<string, object> lstFields = this.GetListFields(entity, "Update");

                    foreach (KeyValuePair<string, object> entry in lstFields)
                    {
                        bool check = false;

                        if (entry.Value != null)
                        {
                            // Verify if value is type of date
                            if (entry.Value.GetType() == typeof(DateTime))
                            {
                                // If source value is null then update with null
                                if (item[entry.Key] != null)
                                {
                                    if ((DateTime)entry.Value != (DateTime)item[entry.Key])
                                        check = true;
                                }
                                else
                                    check = true;
                            }

                            // Verify if value is type of Lookup
                            else if (entry.Value.GetType() == typeof(LookupFieldMapper))
                            {
                                // If source value is null then update with new value
                                if (item[entry.Key] != null)
                                {
                                    // Verify if value is type of Lookup field
                                    if ((item[entry.Key]).GetType() == typeof(FieldLookupValue))
                                    {
                                        if (((FieldLookupValue)item[entry.Key]) != null && ((LookupFieldMapper)entry.Value) != null)
                                        {
                                            if (((FieldLookupValue)item[entry.Key]).LookupId != ((LookupFieldMapper)entry.Value).ID)
                                                check = true;
                                        }
                                        else
                                            check = true;
                                    }

                                    // Verify if value is type of User Lookup field
                                    else
                                    {
                                        if (((FieldUserValue)item[entry.Key]) != null && ((LookupFieldMapper)entry.Value) != null)
                                        {
                                            if (((FieldUserValue)item[entry.Key]).LookupId != ((LookupFieldMapper)entry.Value).ID)
                                                check = true;
                                        }
                                        else
                                            check = true;
                                    }
                                }
                                else
                                    check = true;

                            }
                            // Verify if value is type of string
                            else if (entry.Value.GetType() == typeof(string))
                            {
                                if (item[entry.Key] != null)
                                {
                                    if (entry.Value.ToString().ToLower() != item[entry.Key].ToString().ToLower())
                                        check = true;
                                }
                                else
                                {
                                    if (entry.Value.ToString().ToLower() != "")
                                        check = true;
                                }

                            }
                            else
                            {
                                check = true;
                            }
                        }
                        else
                        {
                            item[entry.Key] = entry.Value;
                        }

                        if (check)
                        {

                            // If type is datetime then need to check if it has default date
                            if (entry.Value.GetType() == typeof(DateTime))
                            {
                                if (((DateTime)entry.Value).Year != 1)
                                    item[entry.Key] = entry.Value;
                            }
                            else if (entry.Value.GetType() == typeof(List<LookupFieldMapper>))
                            {

                                List<FieldUserValue> users = new List<FieldUserValue>();
                                List<LookupFieldMapper> listUsers = (List<LookupFieldMapper>)entry.Value;

                                foreach (LookupFieldMapper user in listUsers)
                                {
                                    FieldUserValue userValue = new FieldUserValue();
                                    userValue.LookupId = (int)user.ID;
                                    users.Add(userValue);
                                }

                                item[entry.Key] = users;
                            }
                            else
                            {
                                // If field type is lookup mapper then need to assign id only
                                if (entry.Value.GetType() == typeof(LookupFieldMapper))
                                    item[entry.Key] = ((LookupFieldMapper)entry.Value).ID;
                                else
                                    item[entry.Key] = entry.Value;
                            }

                        }
                    }

                    item.Update();
                    context.Load<List>(lista);
                    context.Load<Microsoft.SharePoint.Client.ListItem>(item);
                    context.ExecuteQuery();

                    return item;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string DownloadFile<T>(Int32 Id, string TargetPath = "") where T : IEntitySharepointMapper
        {

            try
            {
                using (ClientContext context = new ClientContext(UrlApp))
                {

                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web = context.Web;

                    T entity = (T)Activator.CreateInstance(typeof(T));

                    List allergiesList = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                    CamlQuery query = new CamlQuery();

                    query.ViewXml = GetCamlQueryById(Id.ToString());

                    ListItemCollection items = allergiesList.GetItems(query);

                    context.Load(allergiesList, l => l.RootFolder.ServerRelativeUrl);
                    context.Load(items);
                    context.ExecuteQuery();

                    foreach (ListItem item in items)
                    {

                        var fileRef = (string)item["FileRef"];
                        var fileName = System.IO.Path.GetFileName(fileRef);
                        var filePath = Path.Combine(TargetPath, fileName);

                        Microsoft.SharePoint.Client.File oFile = web.GetFileByServerRelativeUrl(fileRef);

                        context.Load(oFile);
                        ClientResult<Stream> stream = oFile.OpenBinaryStream();
                        context.ExecuteQuery();
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            stream.Value.CopyTo(fileStream);
                        }

                        return filePath;
                    }

                    return "";



                }
            }
            catch (Exception ex)
            {

            }

            return "";

        }

        #region New Item Addition in Doc Library

        /// <summary>
        /// Add new item in document library
        /// </summary>
        /// <typeparam name="T">Type of class which needs to insert in SharePoint Library</typeparam>
        /// <param name="entity">Object of the class tyape</param>
        /// <param name="UploadFilePath">Attachment file path</param>
        /// <param name="Response">By reference paramiter to get the upload log</param>
        /// <param name="DesinationFolder">Destination folder path if any</param>
        /// <param name="UploadAttempt">Attemts to try uploading same file</param>
        /// <param name="RollbackOnUploadFailed">Flag to define rollback method</param>
        /// <returns></returns>
        public ListItem NewLibraryItem<T>(T entity, string UploadFilePath, ref StringBuilder Response, string DestinationFolder = "", int UploadAttempt = 1, bool RollbackOnUploadFailed = false, bool CheckUniqueFile = false) where T : IEntitySharepointMapper
        {

            try
            {

                SKPLib.ProcessLog("------ New Item Creation in Document Library -----", "", "", true);

                // Create folder in destination library
                if (DestinationFolder != "")
                {
                    SKPLib.ProcessLog("1 - Folder creation process initiated - " + DestinationFolder);

                    List<string> FolderList = DestinationFolder.Split('\\').ToList();
                    Folder f = CreateFolderStructureToLibraryRoot(entity, FolderList, ref Response);

                    if (f == null)
                    {
                        SKPLib.ProcessLog("2 - Error in folder creation - " + DestinationFolder);
                        SKPLib.ProcessLog("------ End of New Item Creation in Library -----", "", "", true);
                        return null;
                    }

                    SKPLib.ProcessLog("3 - Folder created successfully - " + DestinationFolder);
                }


                // Identify the file size
                FileStream fs = null;
                fs = System.IO.File.Open(UploadFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                long fileSize = fs.Length;

                // If file size is less than 8MB then call newitemsmall method else call large one : 8MB = 8000000

                ListItem result;

                if (fileSize > 2000)
                {
                    SKPLib.ProcessLog("4 - Invoice upload send to Large file creation with file size - " + fileSize.ToString() + " bytes");
                    result = NewLibraryItemLarge(entity, UploadFilePath, ref Response, fileSize, DestinationFolder, CheckUniqueFile);
                }
                else
                {
                    SKPLib.ProcessLog("5 - Invoice upload send to Small file creation with file size - " + fileSize.ToString() + " bytes");
                    result = NewLibraryItemSmall(entity, UploadFilePath, ref Response, DestinationFolder);
                }


                SKPLib.ProcessLog("------ End of New Item Creation in Library -----", "", "", true);

                return result;

            }
            catch (Exception)
            {
                SKPLib.ProcessLog("N - ");
                SKPLib.ProcessLog("------ End of New Item Creation in Library -----", "", "", true);

                return null;
            }

        }

        /// <summary>
        /// Method to upload large file on SharePoint doc library
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="UploadFilePath"></param>
        /// <param name="Response"></param>
        /// <param name="DesinationFolder"></param>
        /// <returns></returns>
        public ListItem NewLibraryItemLarge<T>(T entity, string UploadFilePath, ref StringBuilder Response, long fileSize, string DesinationFolder = "", bool CheckUniqueFile = false) where T : IEntitySharepointMapper
        {

            #region Define File Block Size

            long blockSize = 7900000; // 8 MB

            if (fileSize <= 8000000)
                blockSize = fileSize - 2000;
            else
                blockSize = 7900000;

            SKPLib.ProcessLog("5 - File black size defined as - " + blockSize.ToString() + " bytes");

            #endregion


            string fileName = UploadFilePath, uniqueFileName = String.Empty;
            Microsoft.SharePoint.Client.File uploadFile = null;
            Guid uploadId = Guid.NewGuid();

            using (ClientContext ctx = new ClientContext(UrlApp))
            {
                // Setting Client Context for the Upload operation
                ctx.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                Web web = ctx.Web;

                List docs = ctx.Web.Lists.GetByTitle(entity.GetSharepointListName());
                ctx.Load(docs.RootFolder, p => p.ServerRelativeUrl);


                //if (CheckUniqueFile)
                //{
                //    string CheckFilePath = Path.Combine("\\" + entity.GetSharepointListName(), DesinationFolder, Path.GetFileName(UploadFilePath));
                //    bool FileFound = false;
                //    Microsoft.SharePoint.Client.File fileToCheck;

                //    try
                //    {
                //        fileToCheck = web.GetFileByServerRelativeUrl(CheckFilePath);
                //        ctx.Load(fileToCheck);
                //        ctx.ExecuteQuery();
                //        FileFound = true;
                //    }
                //    catch (ServerException ex)
                //    {
                //        if (ex.ServerErrorTypeName == "System.IO.FileNotFoundException")
                //        {
                //            FileFound = false;
                //        }
                //    }

                //    if (FileFound)
                //    {
                //        Response.Append("Error Message - already exists. It was last modified by");
                //        Response.AppendLine();

                //        return null;
                //    }

                //}

                // Use large file upload approach
                ClientResult<long> bytesUploaded = null;

                FileStream fs = null;


                try
                {
                    fs = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    fileSize = fs.Length;
                    uniqueFileName = System.IO.Path.GetFileName(fs.Name);

                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] buffer = new byte[blockSize];
                        byte[] lastBuffer = null;
                        long fileoffset = 0;
                        long totalBytesRead = 0;
                        int bytesRead;
                        bool first = true;
                        bool last = false;

                        // Read data from filesystem in blocks
                        while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                        {

                            totalBytesRead = totalBytesRead + bytesRead;

                            // We've reached the end of the file
                            if (totalBytesRead == fileSize)
                            {
                                last = true;
                                // Copy to a new buffer that has the correct size
                                lastBuffer = new byte[bytesRead];
                                Array.Copy(buffer, 0, lastBuffer, 0, bytesRead);
                            }

                            #region Upload First Block

                            if (first)
                            {
                                SKPLib.ProcessLog("6 - First block upload started");

                                using (MemoryStream contentStream = new MemoryStream())
                                {
                                    // Generate file creation information
                                    FileCreationInformation fileCreationInfo = new FileCreationInformation
                                    {
                                        ContentStream = contentStream,
                                        Overwrite = false,
                                        Url = Path.Combine(entity.GetSharepointListName(), DesinationFolder, Path.GetFileName(UploadFilePath))
                                    };
                                    // Upload file to folder
                                    uploadFile = docs.RootFolder.Files.Add(fileCreationInfo);

                                    // Start upload by uploading the first slice.
                                    using (MemoryStream s = new MemoryStream(buffer))
                                    {
                                        // Call the start upload method on the first slice
                                        bytesUploaded = uploadFile.StartUpload(uploadId, s);



                                        // Add all field values to item                      
                                        Dictionary<string, object> lstFields = this.GetListFields(entity, "Insert");

                                        foreach (KeyValuePair<string, object> entry in lstFields)
                                        {
                                            if (entry.Key != "Id" && entry.Key != "Modified" && entry.Key != "Created")
                                            {
                                                if (entry.Value != null)
                                                {

                                                    // If type is datetime then need to check if it has default date
                                                    if (entry.Value.GetType() == typeof(DateTime))
                                                    {
                                                        if (((DateTime)entry.Value).Year != 1)
                                                            uploadFile.ListItemAllFields[entry.Key] = entry.Value;
                                                    }
                                                    else if (entry.Value.GetType() == typeof(List<LookupFieldMapper>))
                                                    {

                                                        List<FieldUserValue> users = new List<FieldUserValue>();
                                                        List<LookupFieldMapper> listUsers = (List<LookupFieldMapper>)entry.Value;

                                                        foreach (LookupFieldMapper user in listUsers)
                                                        {
                                                            FieldUserValue userValue = new FieldUserValue();
                                                            userValue.LookupId = (int)user.ID;
                                                            users.Add(userValue);
                                                        }

                                                        uploadFile.ListItemAllFields[entry.Key] = users;
                                                    }
                                                    else
                                                    {
                                                        // If field type is lookup mapper then need to assign id only
                                                        if (entry.Value.GetType() == typeof(LookupFieldMapper))
                                                            uploadFile.ListItemAllFields[entry.Key] = ((LookupFieldMapper)entry.Value).ID;
                                                        else
                                                            uploadFile.ListItemAllFields[entry.Key] = entry.Value;
                                                    }

                                                }
                                            }
                                        }

                                        // Update item with values
                                        uploadFile.ListItemAllFields.Update();
                                        ListItem item = uploadFile.ListItemAllFields;

                                        ctx.Load(item);
                                        ctx.ExecuteQuery();

                                        

                                        //ctx.ExecuteQuery();
                                        // fileoffset is the pointer where the next slice will be added
                                        fileoffset = bytesUploaded.Value;
                                    }

                                    // we can only start the upload once
                                    first = false;

                                    SKPLib.ProcessLog("6 - First block of file uploaded successfully");
                                }
                            }

                            #endregion

                            #region Get File Uploaded in First Block

                            else
                            {
                                // Get a reference to our file
                                uploadFile = ctx.Web.GetFileByServerRelativeUrl(Path.Combine(docs.RootFolder.ServerRelativeUrl, DesinationFolder, Path.GetFileName(UploadFilePath)));

                                #region Upload Last Block

                                if (last)
                                {
                                    SKPLib.ProcessLog("8 - Last block upload started");

                                    // Is this the last slice of data?
                                    using (MemoryStream s = new MemoryStream(lastBuffer))
                                    {
                                        // End sliced upload by calling FinishUpload
                                        uploadFile = uploadFile.FinishUpload(uploadId, fileoffset, s);


                                        // Add all field values to item                      
                                        Dictionary<string, object> lstFields = this.GetListFields(entity, "Insert");

                                        foreach (KeyValuePair<string, object> entry in lstFields)
                                        {
                                            if (entry.Key != "Id" && entry.Key != "Modified" && entry.Key != "Created")
                                            {
                                                if (entry.Value != null)
                                                {

                                                    // If type is datetime then need to check if it has default date
                                                    if (entry.Value.GetType() == typeof(DateTime))
                                                    {
                                                        if (((DateTime)entry.Value).Year != 1)
                                                            uploadFile.ListItemAllFields[entry.Key] = entry.Value;
                                                    }
                                                    else if (entry.Value.GetType() == typeof(List<LookupFieldMapper>))
                                                    {

                                                        List<FieldUserValue> users = new List<FieldUserValue>();
                                                        List<LookupFieldMapper> listUsers = (List<LookupFieldMapper>)entry.Value;

                                                        foreach (LookupFieldMapper user in listUsers)
                                                        {
                                                            FieldUserValue userValue = new FieldUserValue();
                                                            userValue.LookupId = (int)user.ID;
                                                            users.Add(userValue);
                                                        }

                                                        uploadFile.ListItemAllFields[entry.Key] = users;
                                                    }
                                                    else
                                                    {
                                                        // If field type is lookup mapper then need to assign id only
                                                        if (entry.Value.GetType() == typeof(LookupFieldMapper))
                                                            uploadFile.ListItemAllFields[entry.Key] = ((LookupFieldMapper)entry.Value).ID;
                                                        else
                                                            uploadFile.ListItemAllFields[entry.Key] = entry.Value;
                                                    }

                                                }
                                            }
                                        }

                                        // Update item with values
                                        uploadFile.ListItemAllFields.Update();
                                        ListItem item = uploadFile.ListItemAllFields;

                                        ctx.Load(item, i => i.File.CheckOutType);
                                        ctx.ExecuteQuery();

                                        SKPLib.ProcessLog("8 - Last block of file uploaded successfully with all fields");

                                        try
                                        {
                                            if (item.File.CheckOutType != CheckOutType.None)
                                            {
                                                item.File.CheckIn(string.Empty, CheckinType.MajorCheckIn);
                                                //item.File.Publish(string.Empty);
                                                ctx.Load(item);
                                                ctx.ExecuteQuery();
                                                SKPLib.ProcessLog("8.1 - File checkOut successfull");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            SKPLib.ProcessLog("8.2 - File checkOut Failed");
                                        }
                                        
                                        

                                        // return the file object for the uploaded file
                                        return uploadFile.ListItemAllFields;
                                    }
                                }

                                #endregion

                                #region Upload Next Block

                                else
                                {
                                    SKPLib.ProcessLog("7 - Next block upload started");

                                    using (MemoryStream s = new MemoryStream(buffer))
                                    {
                                        // Continue sliced upload
                                        bytesUploaded = uploadFile.ContinueUpload(uploadId, fileoffset, s);
                                        ctx.ExecuteQuery();
                                        // update fileoffset for the next slice
                                        fileoffset = bytesUploaded.Value;

                                        SKPLib.ProcessLog("7 - Next block of file uploaded successfully");
                                    }
                                }

                                #endregion
                            }

                            #endregion

                        }
                    }
                }
                catch (Exception e)
                {
                    string strMessage = e.Message != null ? e.Message.ToString() : "";
                    string strTrace = e.InnerException != null ? e.InnerException.ToString() : "";
                    string strException = e.StackTrace != null ? e.StackTrace.ToString() : "";

                    Response.Append("Error Message - " + strMessage);
                    Response.AppendLine();
                    Response.Append("Inner Exception - " + strException);
                    Response.AppendLine();
                    Response.Append("StackTrace - " + strTrace);
                    Response.AppendLine();

                    SKPLib.ProcessLog("9 - File upload failed with error - " + strMessage);

                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }

                return null;
            }

        }

        /// <summary>
        /// Method to upload small file to document library
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="UploadFilePath"></param>
        /// <param name="Response"></param>
        /// <param name="DesinationFolder"></param>
        /// <param name="UploadAttempt"></param>
        /// <param name="RollbackOnUploadFailed"></param>
        /// <returns></returns>
        public ListItem NewLibraryItemSmall<T>(T entity, string UploadFilePath, ref StringBuilder Response, string DesinationFolder = "", int UploadAttempt = 1, bool RollbackOnUploadFailed = false, bool CheckUniqueFile = false) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                context.RequestTimeout = 50000 * 10000;

                for (int FileAttempt = 1; FileAttempt <= UploadAttempt; FileAttempt++)
                {

                    SKPLib.ProcessLog("10 - Upload attempt " + FileAttempt + " started");
                    Response.Append("DOCUMENT UPLOAD ATTEMPT - " + FileAttempt);
                    Response.AppendLine();

                    try
                    {
                        // Setting Client Context for the Upload operation
                        context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                        Web web = context.Web;

                        // Get document library
                        List lista = web.Lists.GetByTitle(entity.GetSharepointListName());

                        // Generate file creation iformation
                        FileCreationInformation fileCreationInfo = new FileCreationInformation
                        {
                            ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(UploadFilePath)),
                            Overwrite = false,
                            Url = Path.Combine(entity.GetSharepointListName(), DesinationFolder, Path.GetFileName(UploadFilePath))
                        };

                        SKPLib.ProcessLog("11 - File creation done");

                        // Upload file to folder
                        Microsoft.SharePoint.Client.File uploadFile = lista.RootFolder.Files.Add(fileCreationInfo);

                        // Add all field values to item                      
                        Dictionary<string, object> lstFields = this.GetListFields(entity, "Insert");

                        SKPLib.ProcessLog("12 - Field identified to upload with document");

                        foreach (KeyValuePair<string, object> entry in lstFields)
                        {
                            if (entry.Value != null)
                            {

                                // If type is datetime then need to check if it has default date
                                if (entry.Value.GetType() == typeof(DateTime))
                                {
                                    if (((DateTime)entry.Value).Year != 1)
                                        uploadFile.ListItemAllFields[entry.Key] = entry.Value;
                                }
                                else
                                {
                                    // If field type is lookup mapper then need to assign id only
                                    if (entry.Value.GetType() == typeof(LookupFieldMapper))
                                        uploadFile.ListItemAllFields[entry.Key] = ((LookupFieldMapper)entry.Value).ID;
                                    else
                                        uploadFile.ListItemAllFields[entry.Key] = entry.Value;
                                }

                            }

                        }

                        SKPLib.ProcessLog("13 - Field values set to ListItem");

                        // Update item with values
                        uploadFile.ListItemAllFields.Update();
                        ListItem item = uploadFile.ListItemAllFields;

                        context.Load(item);
                        //context.Load(uploadFile, f=> f.ListItemAllFields);
                        context.ExecuteQuery();

                        Response.Append("Document uploaded with Document ID - " + item.Id);
                        Response.AppendLine();

                        SKPLib.ProcessLog("14 - Document uploaded successfully with fields");

                        return item;

                    }
                    catch (Exception e)
                    {
                        string strMessage = e.Message != null ? e.Message.ToString() : "";
                        string strTrace = e.InnerException != null ? e.InnerException.ToString() : "";
                        string strException = e.StackTrace != null ? e.StackTrace.ToString() : "";

                        Response.Append("Error Message - " + strMessage);
                        Response.AppendLine();
                        Response.Append("Inner Exception - " + strException);
                        Response.AppendLine();
                        Response.Append("StackTrace - " + strTrace);
                        Response.AppendLine();

                        SKPLib.ProcessLog("15 - Document upload failed with error - " + strMessage);
                        // TODO - Send email to SKP with Error
                    }
                }

                return null;

            }

        }

        #endregion

        #endregion

        #region Common Functions

        /// <summary>
        /// Verify and Create provided folder structure on the root of Document Library
        /// </summary>
        /// <typeparam name="T">Class type of SharePoint list</typeparam>
        /// <param name="FolderStructure">List of strings ParentFolder, ChildFolder, ...</param>
        /// <returns></returns>
        public Folder CreateFolderStructureToLibraryRoot<T>(T entity, List<string> FolderStructure, ref StringBuilder Response) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                try
                {
                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                    Web web = context.Web;
                    List list = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                    context.Load(context.Site);
                    context.ExecuteQuery();

                    Folder returnFolder = list.RootFolder;
                    if (FolderStructure != null && FolderStructure.Count > 0)
                    {
                        Folder currentFolder = list.RootFolder;
                        context.Load(web, t => t.Url);
                        context.Load(currentFolder);
                        context.ExecuteQuery();
                        foreach (string folderPointer in FolderStructure)
                        {
                            FolderCollection folders = currentFolder.Folders;
                            context.Load(folders);
                            context.ExecuteQuery();

                            bool folderFound = false;
                            foreach (Folder existingFolder in folders)
                            {
                                if (existingFolder.Name.Equals(folderPointer, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    folderFound = true;
                                    currentFolder = existingFolder;
                                    break;
                                }
                            }

                            if (!folderFound)
                            {
                                ListItemCreationInformation itemCreationInfo = new ListItemCreationInformation();
                                itemCreationInfo.UnderlyingObjectType = FileSystemObjectType.Folder;
                                itemCreationInfo.LeafName = folderPointer;
                                itemCreationInfo.FolderUrl = currentFolder.ServerRelativeUrl;
                                ListItem folderItemCreated = list.AddItem(itemCreationInfo);
                                folderItemCreated.Update();
                                context.Load(folderItemCreated, f => f.Folder);
                                context.ExecuteQuery();
                                currentFolder = folderItemCreated.Folder;

                                Response.Append("Folder created - " + folderPointer);
                            }
                        }
                        returnFolder = currentFolder;
                    }
                    return returnFolder;
                }
                catch (Exception ex)
                {
                    Response.Append("System Error in folder creation - " + ex.Message.ToString());                    
                    SKPLib.LogSystemError(ex, "", "CreateFolderStructureToLibraryRoot", "Folder Structure Creation in SharePoint Library");
                    return null;
                }
            }

        }

        public Folder searchFolderStructureToLibraryRoot<T>(T entity, List<string> FolderStructure, ref StringBuilder Response) where T : IEntitySharepointMapper
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                try
                {
                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    
                    Web web = context.Web;
                    List list = context.Web.Lists.GetByTitle(entity.GetSharepointListName());

                    context.Load(context.Site);
                    context.ExecuteQuery();

                    Folder returnFolder = list.RootFolder;
                    if (FolderStructure != null && FolderStructure.Count > 0)
                    {
                        Folder currentFolder = list.RootFolder;
                        context.Load(web, t => t.Url);
                        context.Load(currentFolder);
                        context.ExecuteQuery();
                      
                        foreach (string folderPointer in FolderStructure)
                        {

                            FolderCollection folders = currentFolder.Folders;
                            context.Load(folders);
                            context.ExecuteQuery();

                            bool folderFound = false;
                            foreach (Folder existingFolder in folders)
                            {
                                if (existingFolder.Name.Equals(folderPointer, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    folderFound = true;
                                    currentFolder = existingFolder;
                                    break;
                                }
                            }

                            if (!folderFound)
                            {

                            }
                        }
                        returnFolder = currentFolder;
                    }
                    return returnFolder;
                }
                catch (Exception ex)
                {
                    Response.Append("System Error in folder creation - " + ex.Message.ToString());
                    SKPLib.LogSystemError(ex, "", "searchFolderStructureToLibraryRoot", "Folder Structure Creation in SharePoint Library");                    
                    return null;
                }
            }

        }



        /// <summary>
        /// Get the list of perperties and values from class provided, Also it checks for "SharepointFieldName" attributes while extracting values
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="entity">Object to get the property and values</param>
        /// <returns></returns>
        private Dictionary<string, object> GetListFields<T>(T entity, string FieldOperation = "") where T : IEntitySharepointMapper
        {

            Dictionary<string, object> dicProperties = new Dictionary<string, object>();

            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                if (prop.CustomAttributes.Count() == 0)
                    continue;

                if (prop.CustomAttributes.Where(t => t.ConstructorArguments.Count > 0).Count() == 0)
                    continue;

                // Check if property needs to be ignored in operation provided above         
                bool check = false;
                if (FieldOperation != "")
                {
                    if (prop.CustomAttributes.Where(t => t.ConstructorArguments[0].Value.ToString() == FieldOperation).Count() > 0)
                        check = false;
                    else
                        check = true;
                }
                else
                    check = true;

                if (check)
                {
                    foreach (CustomAttributeData attribData in prop.GetCustomAttributesData())
                    {
                        if (attribData.Constructor.DeclaringType.Name == "SharepointFieldName")
                        {
                            if (attribData.ConstructorArguments.Count == 1)
                            {
                                dicProperties.Add(attribData.ConstructorArguments[0].Value.ToString(), prop.GetValue(entity));
                                break;
                            }
                        }
                    }
                }
            }

            return dicProperties;
        }


        /// <summary>
        /// Generate CAML Query by appending provided Item ID
        /// </summary>
        /// <param name="Id">List item id</param>
        /// <returns></returns>
        private String GetCamlQueryById(string Id)
        {
            //return "<View><Query><OrderBy><FieldRef Name='Title' Ascending='TRUE'></FieldRef></OrderBy><Where><Eq><FieldRef Name='ID'  ></FieldRef><Value Type='Number'>" + Id + "</Value></Eq></Where></Query></View>";
            return "<View Scope='RecursiveAll'><Query><OrderBy><FieldRef Name='Title' Ascending='TRUE'></FieldRef></OrderBy><Where><Eq><FieldRef Name='ID'  ></FieldRef><Value Type='Number'>" + Id + "</Value></Eq></Where></Query></View>";
            //return "<Query><OrderBy><FieldRef Name='Title' Ascending='TRUE'></FieldRef></OrderBy><Where><Eq><FieldRef Name='ID'  ></FieldRef><Value Type='Number'>" + Id + "</Value></Eq></Where></Query>";
        }


        public ListItem UploadAttachment<T>(T entity, int ItemID, ref Enums.NewItemStatus iStatus, ref Exception iError, string strFilePath = "") where T : IEntitySharepointMapper
        {
            using (ClientContext context2 = new ClientContext(UrlApp))
            {
                try
                {
                    context2.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web2 = context2.Web;

                    List lista2 = web2.Lists.GetByTitle(entity.GetSharepointListName());
                    ListItem item2 = lista2.GetItemById(ItemID);

                    System.IO.FileInfo aFile = new System.IO.FileInfo(strFilePath);
                    AttachmentCreationInformation attInfo = new AttachmentCreationInformation();
                    attInfo.FileName = aFile.Name;
                    attInfo.ContentStream = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(aFile.FullName));

                    Attachment att = item2.AttachmentFiles.Add(attInfo);

                    context2.Load(att);
                    context2.ExecuteQuery();

                    iError = null;
                    iStatus = Enums.NewItemStatus.CreatedSucsesfully;

                    // Retunr itrm with attachment
                    return item2;
                }
                catch (Exception ex)
                {
                    SKPLib.LogSystemError(ex, "", "UploadAttachment", "Attachment Upload in SharePoint Library");
                    iError = ex;
                    iStatus = Enums.NewItemStatus.FailedInUploadAttachment;
                    return null;
                }
            }
        }

        public ListItem UploadAttachment<T>(T entity, int ItemID, string strFilePath = "") where T : IEntitySharepointMapper
        {
            using (ClientContext context2 = new ClientContext(UrlApp))
            {
                try
                {
                    context2.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web2 = context2.Web;

                    List lista2 = web2.Lists.GetByTitle(entity.GetSharepointListName());
                    ListItem item2 = lista2.GetItemById(ItemID);

                    System.IO.FileInfo aFile = new System.IO.FileInfo(strFilePath);
                    AttachmentCreationInformation attInfo = new AttachmentCreationInformation();
                    attInfo.FileName = aFile.Name;
                    attInfo.ContentStream = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(aFile.FullName));

                    Attachment att = item2.AttachmentFiles.Add(attInfo);

                    context2.Load(att);
                    context2.ExecuteQuery();

                    // iError = null;
                    // iStatus = Enums.NewItemStatus.CreatedSucsesfully;

                    // Retunr itrm with attachment
                    return item2;
                }
                catch (Exception ex)
                {                    
                    SKPLib.LogSystemError(ex, "", "UploadAttachment", "Attachment Upload in SharePoint Library");
                    // iError = ex;
                    //  iStatus = Enums.NewItemStatus.FailedInUploadAttachment;
                    return null;
                }
            }
        }

        public ListItem UploadAttachament(ArchivedDocuments reciveSelectedInvoice, string filePath)
        {
            ListItem lstItems;
            string FilePath = filePath;
            long fileSize = FilePath.Length;

            //LookupFieldMapper _compnay = new LookupFieldMapper();
            //  _compnay.ID = reciveSelectedInvoice.Company.ID;
            // _compnay.Value = reciveSelectedInvoice.Company.Value;

            StringBuilder Response = new StringBuilder();
            //ArchivedDocuments item = new ArchivedDocuments();
            // item.RSN = reciveSelectedInvoice.RSN;
            //item.Company = _compnay;

            FileStream fs = null;
            fs = System.IO.File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fileSize = fs.Length;

            return lstItems = NewLibraryItem<ArchivedDocuments>(reciveSelectedInvoice, FilePath, ref Response, "");


            //lstItems = AppValues.spContext.NewLibraryItem<Supporting>(item, FilePath, ref Response, "", true);

            //if (lstItems == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public List<LookupFieldMapper> GetUserAccounts(List<LookupFieldMapper> userList)
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                try
                {
                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web = context.Web;

                    string strStart = "<View><Query><Where><In><FieldRef Name='ID' /><Values>";
                    string strConditions = "";
                    string strEnd = "</Values></In></Where></Query></View>";
                    CamlQuery cqUserName = new CamlQuery();

                    foreach (LookupFieldMapper user in userList)
                    {
                        if (strConditions == "")
                            strConditions = "<Value Type='Integer'>" + user.ID + "</Value>";
                        else
                            strConditions = strConditions + "<Value Type='Integer'>" + user.ID + "</Value>";
                    }

                    cqUserName.ViewXml = strStart + strConditions + strEnd;

                    ListItemCollection licAuthors = context.Web.SiteUserInfoList.GetItems(cqUserName);

                    context.Load(licAuthors);
                    context.ExecuteQuery();

                    List<LookupFieldMapper> returnUsers = new List<LookupFieldMapper>();

                    foreach (ListItem l in licAuthors)
                    {
                        returnUsers.Add(new LookupFieldMapper() { ID = Convert.ToInt32(l.FieldValues["ID"].ToString()), Value = l.FieldValues["Name"].ToString() });
                    }

                    return returnUsers;

                }
                catch (Exception ex)
                {                    
                    SKPLib.LogSystemError(ex, "", "GetUserAccounts", "Get all user accounts in SharePoint Library");
                    // iError = ex;
                    //  iStatus = Enums.NewItemStatus.FailedInUploadAttachment;
                    return null;
                }
            }
        }


        /// <summary>
        /// Get SharePoint user by ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public User GetUserAccountsByID(int UserID)
        {
            using (ClientContext context = new ClientContext(UrlApp))
            {
                context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                Microsoft.SharePoint.Client.UserCollection users = context.Web.SiteUsers;
                
                context.Load(users, u => u.Where(x => x.Id == UserID));
                context.ExecuteQuery();

                if (users.Count > 0)
                    return users[0];
                else
                    return null;

            }
        }


        /// <summary>
        /// Method to authenticate provided user name and password on SharePoint site
        /// </summary>
        /// <returns></returns>
        public User Authenticate()
        {
            try
            {
                using (ClientContext context = new ClientContext(UrlApp))
                {

                    context.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;
                    Web web = context.Web;

                    User CurrentUser = context.Web.CurrentUser;

                    context.Load(CurrentUser);
                    context.ExecuteQuery(); //LINQ executes here and hits the site to get the data

                    return CurrentUser;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        #endregion

    }

}
