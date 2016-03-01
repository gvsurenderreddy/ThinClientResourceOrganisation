(function( global ) {

	// amita-stringjs:: https://github.com/amita-sd/amita-stringjs.git

	// current version of amita-stringjs, using semantic versioning ( http://semver.org/ )
	var version = '1.0.0';

	// returns true if the candidate is a function
	var is_function = function ( candidate ) {

		return candidate != null && typeof candidate === 'function';

	};

	// check that the exection options for the the register module function has
	// been supplied with the needed properties
	var register_module_options_are_wellformed = function ( register_options ) {

		var result = register_options != null;

		result = result && is_function( register_options.if_node );
		result = result && is_function( register_options.if_amd );
		result = result && is_function( register_options.if_global );

		return result;
	};

	// identify if we in a node enviroments
	var is_nodejs = function ( ) {

		return ( typeof module !== 'undefined' && module.exports );
	};

	// identify if we have an AMD or requirejs.  Note - see http://requirejs.org/docs/node.html#nodeModules 
	var is_amd = function ( ) {

		return ( typeof define === 'function' );
	};

	var register_module = function ( register_options ) {

		if ( !register_module_options_are_wellformed( register_options ) ) { throw new Error( 'register_options are not well formed.' ); }


		if ( is_nodejs() ) {
			register_options.if_node( module );
			return;
		
		} else if ( is_amd() ) {
			register_options.if_amd( );
		
		} else {
			register_options.if_global();	
		}
	};

	var amita_string = {
		version: version,
	};


    // ReplaceParameters
    //
	// Creates a new string by replacing the parameter markers in the the
	// template with the appropriate value from the substitutions.
	// 
	//  e.g.
	//  
    //  var statement_template = 'this is a {operation} on {item}'
    //  
    //  var statement = amita_stringjs.ReplaceParametes( statement_template,  
    //        operation = "a test"
    //      , item = "ReplaceParametes"
    //  });
    //
    //  expected -> statement === 'this is a test on ReplaceParametes'
	// 
	//
	//
	// A parameter marker is a region of the template text wrapped in {}. When a 
	// template is found it is replaced with a the value of the property in the	 
	//  substitutions object with the same name.
	amita_string.ReplaceParameters = function ( template, substitutions ) {

		var result = template;

		for ( var parameter_name in substitutions ) {
			// Note we are using a regular expression because the standard replace does not
			//      replace multiple occurences in the string.
			result = result.replace( new RegExp('\{' + parameter_name + '\}',"gm"), substitutions[parameter_name]);
        }
		return result;
	};


	return register_module({

		if_node: function ( ) {
			module.exports = amita_string;
		},

		if_amd: function () {

			define( [], function () {
				return amita_string;
			});
		},

		if_global: function ( ) {
			global.amita_stringjs = amita_string;
		}
	});


})(this);