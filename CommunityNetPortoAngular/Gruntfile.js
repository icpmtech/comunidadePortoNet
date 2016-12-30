/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        concat: {
            css: {
                src: ['lib/bootstrap/dist/css/bootstrap.css', 'Content/Site.css'],
                dest: 'css/styles.css'
            },
        },

        cssmin: {
            css: {
                src: 'css/styles.css',
                dest: 'css/styles.min.css'
            }
        }
    });
    // Load the plugin that provides the tasks we need
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    // Default task(s).
    grunt.registerTask('default', []);

    // Build task(s).
    grunt.registerTask('build:css', ['concat:css', 'cssmin:css']);
};