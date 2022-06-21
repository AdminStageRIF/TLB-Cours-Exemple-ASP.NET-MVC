function postForm(lang, url) {
  // on récupère le deuxième formulaire du document
  var form = document.forms[1];
  // on lui ajoute l'attribut caché lang
  var hiddenField = document.createElement("input");
  hiddenField.setAttribute("type", "hidden");
  hiddenField.setAttribute("name", "lang");
  hiddenField.setAttribute("value", lang);
  // ajout du champ caché dans le formulaire
  form.appendChild(hiddenField);
  // on lui ajoute l'attribut caché url
  var hiddenField = document.createElement("input");
  hiddenField.setAttribute("type", "hidden");
  hiddenField.setAttribute("name", "url");
  hiddenField.setAttribute("value", url);
  // ajout du champ caché dans le formulaire
  form.appendChild(hiddenField);
  // soumission
  form.submit();
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

