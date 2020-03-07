/// <binding BeforeBuild='default' Clean='clean' />
var gulp = require("gulp");
var del = require('del');

gulp.task('clean', function () {
    return del(['wwwroot/Shipwreck.BlazorJqueryToast.*']);
});
gulp.task('bundle', function () {
    return gulp.src([
        '../Shipwreck.BlazorJqueryToast/wwwroot/Shipwreck.BlazorJqueryToast.css',
        '../Shipwreck.BlazorJqueryToast/wwwroot/Shipwreck.BlazorJqueryToast.js'
    ]).pipe(gulp.dest('wwwroot/'));
});
gulp.task('default', gulp.series(['clean', 'bundle']));