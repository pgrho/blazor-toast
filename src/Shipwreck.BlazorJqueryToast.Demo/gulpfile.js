/// <binding AfterBuild='default' Clean='clean' />
var gulp = require("gulp");
var del = require('del');

gulp.task('clean', function () {
    return del(['wwwroot/js', 'wwwroot/css']);
});
gulp.task('lib', function () {
    return gulp.src(['../Shipwreck.BlazorJqueryToast/wwwroot/**/*'])
        .pipe(gulp.dest('wwwroot'));
});
gulp.task('default', gulp.series(['clean', 'lib']));