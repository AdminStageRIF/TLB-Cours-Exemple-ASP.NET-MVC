function postForm() {
  // on fait un appel Ajax à la main
  var formulaire = $("#formulaire");
  var résultats = $('#résultats');
  $.ajax({
    url: '/Premier/Action02Post',
    type: 'POST',
    data: formulaire.serialize(),
    dataType: 'json',
    beforeSend: OnBegin,
    success: OnSuccess,
    error: OnFailure,
    complete: OnComplete
  })
}

// au chargement du document
$(document).ready(function () {
  // on cache certains éléments de la page
  $("#entete").hide();
  $("#résultats").hide();
  $("#erreur").hide();
});

// démarrage
function OnBegin() {
  // signal d'attente allumé
  $("#loading").show();
  // on cache certains éléments de la page
  $("#entete").hide();
  $("#résultats").hide();
  $("#erreur").hide();
}

// démarrage
function OnComplete() {
  // signal d'attente éteint
  $("#loading").hide();
}

// réussite
function OnSuccess(data) {
  // affichage résultats
  $("#heureCalcul").first().text(data.HeureCalcul);
  $("#entete").show();
  if (data.Erreur != '') {
    $("#msg").first().text(data.Erreur);
    $("#erreur").show();
    return;
  }
  // pas d'erreur
  $("#AplusB").first().text(data.AplusB);
  $("#AmoinsB").first().text(data.AmoinsB);
  $("#AmultipliéparB").first().text(data.AmultipliéparB);
  $("#AdiviséparB").first().text(data.AdiviséparB);
  $("#résultats").show();
}

// erreur
function OnFailure(request, error) {
  alert("L'erreur suivante s'est produite :" + error);
}

// http://blog.instance-factory.com/?p=268
$.validator.methods.number = function (value, element) {
  return this.optional(element) ||
      !isNaN(Globalize.parseFloat(value));
}

$.validator.methods.date = function (value, element) {
  return this.optional(element) ||
      !isNaN(Globalize.parseDate(value));
}

jQuery.extend(jQuery.validator.methods, {
  range: function (value, element, param) {
    //Use the Globalization plugin to parse the value        
    var val = Globalize.parseFloat(value);
    return this.optional(element) || (
        val >= param[0] && val <= param[1]);
  }
});
