define(['can', 'jquery'], function(can, $) {
	can.Control.extend('Languages', {
			defaults: {
				history: [],
				currentIndex: -1,
				words: {},
				dictionaryType: 'FR-RO'
			},
			init: function(el, options) {
			}
		},
		{
			init: function(el, options) {
				var me = this, o = me.options;

				o.dictionaryType = $('#Types').val();
			},
			
			'{window} keydown': function (el, ev) {
				var me = this;
				var keyCode = ev.keyCode || ev.which;

				switch (keyCode) {
					case 39:
						me._next();
						break;

					case 37:
						me._back();
						break;

					case 38:
					case 40:
						me._showTranslation();
						break;
				}
			},
				
			'.next click': function (el, options) {
				var me = this;
				
				me._next();
			},
			
			'#fromBox click': function (el, options) {
				var me = this;

				me._next();
			},
			
			'.back click': function (el, options) {
				var me = this;
				
				me._back();
			},
			
			'#toBox click': function () {
				var me = this;
				
				me._showTranslation();
			},
			
			'#Types change': function (el, options) {
				var me = this, o = me.options;

				o.dictionaryType = el.val();
			},
			
			_next: function () {
				var me = this;

				var word = me._getNextWord();
				me._setWord(word);
			},
			
			_back: function () {
				var me = this;

				var word = me._getPreviousWord();
				me._setWord(word);
			},
			
			_getNextWord: function () {
				var me = this, o = me.options;

				var indexToRetrieve;
				if (o.currentIndex < o.history.length - 1) {
					indexToRetrieve = o.history[++o.currentIndex];
				}
				else {
					indexToRetrieve = Math.floor(Math.random() * o.words.length);
					o.history.push(indexToRetrieve);
					o.currentIndex++;
				}

				var word = o.words[indexToRetrieve];

				return word;
			},
			
			_getPreviousWord: function () {
				var me = this, o = me.options;
				
				var word = { "from": "&nbsp;", "to": "&nbsp;" };
				if (o.history.length == 0)
					return word;
	
				var indexToRetrieve;
				if (o.currentIndex == 0) {
					indexToRetrieve = o.history[0];
				}
				else {
					indexToRetrieve = o.history[--o.currentIndex];
				}

				word = o.words[indexToRetrieve];
				return word;
			},
			
			_setWord: function (word) {

				var me = this, o = me.options;

				var from = $("#from");
				var to = $("#to");
				var toDescription = $("#toDescription");
				var fromDescription = $("#fromDescription");

				$("#toBox").css("color", "white");

				if (o.dictionaryType == 'FR-RO') {
					from.html(word.from);
					to.html(word.to);
					fromDescription.html(word.description);
					toDescription.html("");
				}
				else {
					from.html(word.to);
					to.html(word.from);
					toDescription.html(word.description);
					fromDescription.html("");
				}
			},
			
			_showTranslation: function () {
				$("#toBox").css("color", "");
			}
		});
});