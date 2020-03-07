/// <binding BeforeBuild='default' Clean='clean' />
var gulp = require("gulp");
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');

gulp.task('clean', function () {
    return del(['wwwroot/*.js']);
});
gulp.task('bundle', function () {
    return gulp.src([
        'Scripts/jquery.toast.min.js',
        'Scripts/shim.js'
    ])
        .pipe(concat('Shipwreck.BlazorJqueryToast.js'))
        .pipe(gulp.dest('wwwroot/'));
});
gulp.task('default', gulp.series(['clean', 'bundle']));