$(document).ready(function () {
    updateItems();

    $('#add-dollar-button').on("click", function(){
      var currentMoneyInMachine=$("#money-inserted-display").val();
      if (isNaN(currentMoneyInMachine))
      {
        currentMoneyInMachine=Number(0.00);
      }
      else
      {
        currentMoneyInMachine=Number(currentMoneyInMachine) + Number(1);
      }
      $("#display-change-window").val(null);
      $("#display-message").val(null);
      $("#money-inserted-display").val(currentMoneyInMachine.toFixed(2));
    });


    $('#add-quarter-button').on("click", function(){
      var currentMoneyInMachine=$("#money-inserted-display").val();
      if (isNaN(currentMoneyInMachine))
      {
        currentMoneyInMachine=Number(0.00);
      }
      else
      {
        currentMoneyInMachine=Number(currentMoneyInMachine) + Number(0.25);
      }
      $("#display-change-window").val(null);
      $("#display-message").val(null);
      $("#money-inserted-display").val(currentMoneyInMachine.toFixed(2));
    });


    $('#add-dime-button').on("click", function(){
      var currentMoneyInMachine=$("#money-inserted-display").val();
      if (isNaN(currentMoneyInMachine))
      {
        currentMoneyInMachine=Number(0.00);
      }
      else
      {
        currentMoneyInMachine=Number(currentMoneyInMachine) + Number(0.10);
      }
      $("#display-change-window").val(null);
      $("#display-message").val(null);
      $("#money-inserted-display").val(currentMoneyInMachine.toFixed(2));
    });


    $('#add-nickel-button').on("click", function(){
      var currentMoneyInMachine=$("#money-inserted-display").val();
      if (isNaN(currentMoneyInMachine))
      {
        currentMoneyInMachine=Number(0.00);
      }
      else
      {
        currentMoneyInMachine=Number(currentMoneyInMachine) + Number(0.05);
      }
      $("#display-change-window").val(null);
      $("#display-message").val(null);
      $("#money-inserted-display").val(currentMoneyInMachine.toFixed(2));
    });


function renderItem(item){
  return `   <div class="col-md-4 vendingItem text-center" data-itemid='${item.id}'>
                <p>${item.id}</p>
                <p>${item.name}</p>
                <p>$${item.price.toFixed(2)}</p>
                <br />
                <p> Quantity Left: ${item.quantity} <p/>
            </div>`
}


function updateItems(){
    var itemContents = $("#itemArray");
    itemContents.empty();
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function(vendingArray){
            itemContents.append(vendingArray.map((item)=>
            {return renderItem(item);
            }))
        },
        error: function(){

        }
})}

$(document).on("click", ".vendingItem", function(e){
  $("#item-id-choosen").val($(this).data('itemid'));
})
$("#make-purchase").on("click", function(){

      var moneyAvailable = $("#money-inserted-display").val();
      var itemId = $("#item-id-choosen").val();
      if(itemId=="")
      {
        $("#display-message").val("Please choose an item.");
      }
      else if(moneyAvailable == 0)
      {
        $("#display-message").val("Please insert money.");
      }
      else{
      $.ajax({
        type: "GET",
        url: "http://localhost:8080/money/" + moneyAvailable + "/item/" + itemId,
        success: function (data){

              var changeDispensed = "Quarters: " + data.quarters + " Dimes: " + data.dimes + " Nickels: " + data.nickels + " Pennies: " + data.pennies;
              $("#display-change-window").val(changeDispensed);
              $("#display-message").val("Thank You!");
              $("#money-inserted-display").val("");
              $("#item-id-choosen").val("");
              updateItems();
        },
        error: function(rsp){

              $("#display-message").val(rsp.responseJSON.message);
        },
      })
    }
  })

$("#return-change-button").on("click", function(){

    var moneyInTotalIn = $("#money-inserted-display").val();
    if(moneyInTotalIn == 0 || moneyInTotalIn == null)
    {
      $("#money-inserted-display").val("");
      $("#display-message").val("");
      $("item-id-choosen").val("");
    }
    else
    {
      var changeDispensed = "Quarters: " + data.quarters + " Dimes: " + data.dimes + " Nickels: " + data.nickels + "Pennies: " + data.pennies;
      $("display-change-window").val(changeDispensed);
      $("#money-inserted-display").val("");
      $("#display-message").val("");
      $("item-id-choosen").val("");

    }
  })
})
