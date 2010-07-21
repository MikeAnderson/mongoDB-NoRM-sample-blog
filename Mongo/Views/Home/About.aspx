<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Mongo Info
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Getting Started Info</h2>
    <p>NoRM: <a href="http://normproject.org/" target="_blank">NoRM</a></p>
    <p>Mongo Driver: <a href="http://github.com/samus/mongodb-csharp" target="_blank">mongodb-csharp</a></p>
    <p>mongoDB Site: <a href="http://www.mongodb.org/display/DOCS/Developer+Zone" target="_blank">http://www.mongodb.org</a></p>
    <p>Excellent reCAPTCHA reference: <a href="http://devlicio.us/blogs/derik_whittaker/archive/2008/12/02/using-recaptcha-with-asp-net-mvc.aspx" target="_blank">http://devlicio.us/blogs/derik_whittaker/</a></p>    
    <p>Quickstart: <a href="http://www.mongodb.org/display/DOCS/Quickstart+Windows" target="_blank">http://www.mongodb.org/display/DOCS/Quickstart+Windows</a></p>


    <p>
        The important binaries for a first run are:<br /><br />

        * mongod.exe - the database server<br />
        * mongo.exe - the administrative shell<br /><br />

        I created a folder c:\mongodb. Everything going forward references this folder.<br /><br />
        To start the database, from a CMD window run these commands:<br />

        C:\> cd \mongodb\bin<br />
        C:\mongodb\bin > mongod.exe --dbpath c:\mongodb\data (I specify the data path)<br /><br />

        Once the database is started, you can monitor it via a browser at: <a href="http://localhost:28017/" target="_blank">http://localhost:28017/</a><br /><br />

        (To stop the database, go back to this open command prompt and hit [ctrl + c])<br /><br />

        To start the administartive shell (with the database running), open a command prompt and run these commands:<br />
        C:\> cd \mongodb\bin<br />
        C:\mongodb\bin > mongo.exe<br /><br />
        
        (Run mongo --help to view other options)<br /><br />

        C:\> cd \mongodb\bin<br />
        C:\mongodb\bin> mongo<br /><br />
        Some simple mongo (or java) commands:<br />
        > // the mongo shell is a javascript shell connected to the db<br />
        > 3+3<br />
        6<br />
        > show dbs<br />
        > db<br />
        test<br />
        > // the first write will create the db:<br />
        > db.foo.insert( { a : 1 } )<br />
        > db.foo.find()<br />
        { _id : ..., a : 1 }<br /><br />

        ** If you setup authentication, run these commands:<br />
        > use admin<br />
        > db.authenticate("dba","password")<br />
        > use MongoBlog<br />
        > db.authenticate("userid","password")<br /><br />

    </p>
    <h2>Mongo as a service</h2>
        <p>The three service related commands are:
            <ul>
                <li>mongod --install</li>
                <li>mongod --service</li>
                <li>mongod --remove</li>
            </ul>
        </p>
        <p>The --install and --remove options install and remove the mongo daemon as a windows service respectively. The --service option starts the service.</p>        
        <p>Open command shell as Administartor (won't work without it) and run: c:\mongodb\bin\mongod --install</p>
        <p>Run regedit from the command prompt. Go to HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\MongoDB and edit the ImagePath to suit your needs.</p>        
        <p>example: c:\mongodb\bin\mongod.exe --service  --dbpath=c:\mongodb\data --directoryperdb (note: change --install to --service in the registry key)</p>
        <p>Monitor Mongo: <a href="http://localhost:28017/" target="_blank">http://localhost:28017/</a></p>
        <p>Everything should show up under services, yeehaw!</p>
    <h2>Commands</h2>
    <p>
        These are all from the mongoDB website (<a href="http://www.mongodb.org/display/DOCS/dbshell+Reference" target="_blank">http://www.mongodb.org/display/DOCS/dbshell+Reference</a>), these were added here for quick local reference.
        <ul>
            <li>show dbs - Print a list of all databases on this server</li>
            <li>use dbname - Set the db variable to represent usage of dbname on the server</li>
            <li>show collections - Print a list of all collections for current database</li>
            <li>show users - Print a list of users for current database</li>
            <li>show profile - Print most recent profiling operations that took >= 1ms </li>        
            <li>db - The variable that references the current database object / connection. Already defined for you in your instance.</li> 
            <li>db.auth(user,pass) - Authenticate with the database (if running in secure mode).</li> 
            <li>db.cloneDatabase(fromhost) - Clone the current database from the other host specified. fromhost database must be in noauth mode.</li>
            <li>db.copyDatabase(fromdb, todb, fromhost) - Copy fromhost/fromdb to todb on this server. fromhost must be in noauth mode.</li>
            <li>db.repairDatabase() - Repair and compact the current database. This operation can be very slow on large databases.</li>
            <li>db.addUser(user,pwd) - Add user to current database.</li>
            <li>db.getCollectionNames() - get list of all collections.</li>
            <li>db.dropDatabase() -	Drops the current database. </li>
           </ul>
            <b>Collection Methods</b>
           <ul>
            <li>coll = db.collection - Access a specific collection within the database.</li> 
            <li>cursor = coll.find(); - Find all objects in the collection. See queries.</li> 
            <li>coll.remove(objpattern); - Remove matching objects from the collection. objpattern is an object specifying fields to match. E.g.: coll.remove( { name: "Joe" } );</li> 
            <li>coll.save(object); - Save an object in the collection, or update if already there. If your object has a presave method, that method will be called before the object is saved to the db (before both updates and inserts)</li> 
            <li>coll.insert(object); - Insert object in collection.  No check is made (i.e., no upsert) that the object is not already present in the collection.</li> 
            <li>coll.update(...) Update an object in a collection.  See the Updating documentation; update() has many options.</li> 
            <li>coll.ensureIndex( { name : 1 } ) - Creates an index on tab.name. Does nothing if index already exists.</li> 
            <li>coll.update(...) 	 </li> 
            <li>coll.drop() - Drops the collection coll</li> 
            <li>db.getSisterDB(name) - Switch to another database using this same connection. Simpilar to "use name" but works as a normal javascript expression</li> 
           </ul>
            <b>Find Methods</b>
           <ul>
            <li>coll.find() - Find all. it Continue iterating the last cursor returned from find().</li> 
            <li>coll.find( criteria ); - Find objects matching criteria in the collection. E.g.: coll.find( { name: "Joe" } );</li> 
            <li>coll.findOne( criteria ); - Find and return a single object. Returns null if not found. If you want only one object returned, this is more efficient than just find() as limit(1) is implied. You may use regular expressions if the element type is a string, number, or date: coll.find( { name: /joe/i } );</li> 
            <li>coll.find( criteria, fields ); 	- Get just specific fields from the object. E.g.: coll.find( {}, {name:true} );</li> 
            <li>coll.find().sort( {field:1[, field:1] }); - Return results in the specified order (field ASC). Use -1 for DESC.</li> 
            <li>coll.find( criteria ).sort( { field : 1 } ) - Return the objects matching criteria, sorted by field.</li> 
            <li>coll.find( ... ).limit(n) - Limit result to n rows. Highly recommended if you need only a certain number of rows for best performance.</li> 
            <li>coll.find( ... ).skip(n ) - Skip n results.</li> 
            <li>coll.count() - Returns total number of objects in the collection.</li> 
            <li>coll.find( ... ).count() - Returns the total number of objects that match the query. Note that the number ignores limit and skip; for example if 100 records match but the limit is 10, count() will return 100. This will be faster than iterating yourself, but still take time.  </li> 
            <li>db.collection.find({"first_name" : "John" } )</li>
            <li>db.collection.find({"first_name": /^J/ }) </li>
            <li>db.collection.find_first({"_id" : 1})</li>
            <li>db.collection.find({"age" : {"$gt": 21}})</li>
            <li>db.collection.find({"author.first_name" : "John" })</li>
            <li>db.collection.find({$where : "this.age >= 6 && this.age <= 18"})</li>

        </ul>
    
    </p>
</asp:Content>
