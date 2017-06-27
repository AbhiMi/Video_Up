<?php
$raddeviceid = $_GET['RADDeviceID'];
$companyid = $_GET['CompanyID'];

$serverName = "73.20.106.123,1433\SQLEXPRESS"; //serverName\instanceName
$connectionInfo = array( "Database"=>"Video-Up", "UID"=>"VideoUp", "PWD"=>"vup123");
$conn = sqlsrv_connect( $serverName, $connectionInfo);

if( $conn === false ) {
    die( print_r( sqlsrv_errors(), true));
}

/* Define the Transact-SQL query. Use question marks (?) in place of
the parameters to be passed to the stored procedure */
$tsql_callSP = "{call SP_GetGoLiveVideo( ?, ?)}";

$params = array( 
                 array($raddeviceid, SQLSRV_PARAM_IN),
                 array($companyid, SQLSRV_PARAM_IN)
               );
$stmt = sqlsrv_query( $conn, $tsql_callSP, $params);
if( $stmt === false )
{
     echo "Error in statement execution.</br>";
     die( print_r( sqlsrv_errors(), true));
}

/* Retrieve and display the data.
The return data is retrieved as a binary stream. */
if ( sqlsrv_fetch( $stmt ) )
{
   $image = sqlsrv_get_field( $stmt, 0, 
                      SQLSRV_PHPTYPE_STREAM(SQLSRV_ENC_BINARY));
   header("Content-Type: video/mp4");

//Save file at C:\VideoUp\RADFilestoplay
//Store a lineup XML file for video order

   fpassthru($image);
}
else
{
     echo "Error in retrieving data.</br>";
     die(print_r( sqlsrv_errors(), true));
}

/* Free statement and connection resources. */
sqlsrv_free_stmt( $stmt);
sqlsrv_close( $conn);

	
?>