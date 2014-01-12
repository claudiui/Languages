var history = [];
var currentIndex = -1;

(function () {
	$(document).ready(function() {

		$(document).bind("keydown", HandleKeyDown);

		$("#fromBox, .next").bind("click tap", function () {
			GoNext();
		});
		
		$(".back").bind("click tap", function () {
			GoBack();
		});
		
		$("#toBox").bind("click tap", function () {
			ShowTranslation();
		});
	});

})(jQuery);

function HandleKeyDown(e) {
	var keyCode = e.keyCode || e.which;
	
	switch (keyCode) {
		case 39:
			GoNext();
			break;

		case 37:
			GoBack();
			break;
		 		
		case 38:
		case 40:
			ShowTranslation();
			break;
	}
}

function GoNext() {
	var word = GetNext();
	SetWord(word);
}

function GoBack() {
	var word = GetPrevious();
	SetWord(word);
}

function ShowTranslation() {
	$("#to").css("visibility", "visible");
}

function SetWord(word) {
	var from = $("#from");
	var to = $("#to");

	to.css("visibility", "hidden");

	from.html(word.from);
	to.html(word.to);
}

function GetPrevious() {
	var word = { "from": "&nbsp;", "to": "&nbsp;" };
	if (history.length == 0)
		return word;
	
	var indexToRetrieve;
	if (currentIndex == 0) {
		indexToRetrieve = history[0];
	}
	else {
		indexToRetrieve = history[--currentIndex];
	}

	word = words[indexToRetrieve];
	return word;
}

function GetNext()
{
	var indexToRetrieve;
	if (currentIndex < history.length - 1) {
		indexToRetrieve = history[++currentIndex];
	}
	else {
		indexToRetrieve = Math.floor(Math.random() * words.length);
		history.push(indexToRetrieve);
		currentIndex++;
	}
	
	var word = words[indexToRetrieve];

	return word;
}