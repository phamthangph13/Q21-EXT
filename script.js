function createOK() {
    const ok = document.createElement('div');
    ok.className = 'ok';
    ok.style.left = Math.random() * 100 + '%';
    ok.style.animationDuration = Math.random() * 2 + 3 + 's';
    ok.style.opacity = Math.random() * 0.5 + 0.5;
    ok.style.fontSize = Math.random() * 24 + 12 + 'px';
    ok.innerText = 'OK';

    document.getElementById('ok-container').appendChild(ok);

    // Xóa phần tử sau khi animation kết thúc
    ok.addEventListener('animationend', () => {
        ok.remove();
    });
}

// Tạo OK mới mỗi 100ms
setInterval(createOK, 100); 