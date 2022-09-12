const jq = jQuery.noConflict();

jq(($) => {
  var table = $("#transactionsTable").DataTable({
    sDom: "rtip",
    lengthChange: false,
    info: false,
    ordering: false,
    scrollY: true,
    scrollX: true,
    searching: false,
    serverSide: true,
    processing: true,
    ajax: {
      url: "/api/users/transactions",
      //dataSrc: (json) => {
      //var returnData = new Array();
      //for (var i = 0; i < json.data.length; i++) {
      // var transaction = json.data[i];
      // returnData.push({
      // updated_at: transaction.updated_at,
      // amount: transaction.amount,
      // currency: transaction.currency,
      // receiver: transaction.receiver,
      // subject: transaction.subject
      // })
      //}
      //console.log("returnData is");
      //console.log(returnData);
      //return returnData;
      //}
    },
    columns: [
      {
        title: "Date",
        data: "updated_at",
        render: (data, type, row) => {
          var DateTime = luxon.DateTime;
          var readableTime = DateTime.fromISO(data).toLocaleString(
            DateTime.DATETIME_FULL,
          );
          // Apparently Fidor stores time in UTC timezone...
          return readableTime;
        },
      },
      {
        title: "Amount",
        data: "amount",
        render: (data, type, row) => {
          var formatter = new Intl.NumberFormat("en-SG", {
            style: "currency",
            currency: row.currency,
          });

          return formatter.format(data / 100);
        },
      },
      {
        title: "Receiver",
        data: "receiver",
        render: (data, type, row) => {
          if (validate.single(data, { email: true }) == undefined) {
            return "<a href='mailto:" + data + "'>" + data + "</a>";
          } else {
            return row.recipient_name;
          }
        },
      },
      { title: "Message", data: "subject" },
    ],
  });
});
