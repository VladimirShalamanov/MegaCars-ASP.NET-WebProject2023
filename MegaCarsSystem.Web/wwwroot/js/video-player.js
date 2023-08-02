document.addEventListener('DOMContentLoaded', () => {

    var videos = ['/videos/video1.mp4', '/videos/video2.mp4', '/videos/video3.mp4'];
    var currentVideoIndex = 0;

    var videoPlayer = document.getElementById('videoPlayer');

    if (videoPlayer != null) {

        videoPlayer.addEventListener('ended', () => {

            var videoElement = videoPlayer.children[0];

            if (currentVideoIndex < videos.length - 1) {
                currentVideoIndex++;
            }
            else {
                currentVideoIndex = 0;
            }

            videoElement.setAttribute("src", videos[currentVideoIndex]);

            videoPlayer.load();
            videoPlayer.play();
        });
    }
});