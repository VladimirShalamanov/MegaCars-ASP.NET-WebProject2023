document.addEventListener('DOMContentLoaded', function () {
    var videoPlayer = document.getElementById('videoPlayer');
    var videoElement = videoPlayer.children[0];
    var videos = ['/videos/video1.mp4', '/videos/video2.mp4', '/videos/video3.mp4'];
    var currentVideoIndex = 0;

    videoPlayer.addEventListener('ended', function () {
        if (currentVideoIndex < videos.length - 1) {
            currentVideoIndex++;
            videoElement.setAttribute("src", videos[currentVideoIndex]);

            videoPlayer.load(); 
            videoPlayer.play();
        }
        else {
            // All videos have played; you can choose to loop or stop here
            // For example, to loop back to the first video, use:
            currentVideoIndex = 0;
            videoElement.setAttribute("src", videos[currentVideoIndex]);

            videoPlayer.load();
            videoPlayer.play();
        }
    });
});