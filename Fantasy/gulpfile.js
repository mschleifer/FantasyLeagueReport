const gulp = require('gulp');
const rename = require('gulp-rename');

gulp.task('styles', () => {
    const postcss = require('gulp-postcss');

    return gulp.src('./Styles/fantasy.css')
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer')
        ]))
        .pipe(rename("app.css"))
        .pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('styles-prod', () => {
    const postcss = require('gulp-postcss');
    const purgecss = require('gulp-purgecss');
    const cleanCSS = require('gulp-clean-css');

    return gulp.src('./Styles/fantasy.css')
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer')
        ]))
        .pipe(purgecss({ content: ['**/*.html', '**/*.razor'] }))
        .pipe(rename("app.css"))
        .pipe(cleanCSS({ level: 2 }))
        .pipe(gulp.dest('./wwwroot/css/'));
});