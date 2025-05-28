// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Manipulação do dropdown de notificações
document.addEventListener('DOMContentLoaded', function() {
    // Controle do dropdown de notificações
    const notificationIcon = document.getElementById('notificationIcon');
    const notificationDropdown = document.getElementById('notificationDropdown');

    if (notificationIcon && notificationDropdown) {
        notificationIcon.addEventListener('click', function(e) {
            e.preventDefault();
            e.stopPropagation();
            notificationDropdown.style.display = notificationDropdown.style.display === 'block' ? 'none' : 'block';
        });

        // Fechar o dropdown quando clicar fora dele
        document.addEventListener('click', function(e) {
            if (!notificationDropdown.contains(e.target) && e.target !== notificationIcon) {
                notificationDropdown.style.display = 'none';
            }
        });

        // Prevenir que o dropdown feche quando clicar dentro dele
        notificationDropdown.addEventListener('click', function(e) {
            e.stopPropagation();
        });
    }
});

// Carregamento dinâmico de conteúdo
document.addEventListener('DOMContentLoaded', function() {
    const notificationsLink = document.getElementById('notificationsLink');
    const mainContent = document.getElementById('mainContent');

    // Função para carregar conteúdo
    async function loadContent(url) {
        try {
            const response = await fetch(url);
            if (!response.ok) throw new Error('Erro ao carregar conteúdo');
            const content = await response.text();
            mainContent.innerHTML = content;
        } catch (error) {
            console.error('Erro:', error);
            mainContent.innerHTML = '<div class="alert alert-danger">Erro ao carregar o conteúdo. Por favor, tente novamente.</div>';
        }
    }

    // Evento de clique no link de notificações
    if (notificationsLink) {
        notificationsLink.addEventListener('click', function(e) {
            e.preventDefault();
            const url = this.getAttribute('data-content-url');
            if (url) {
                // Atualiza a URL sem recarregar a página
                history.pushState({}, '', '/notifications');
                // Carrega o conteúdo
                loadContent(url);
                // Atualiza visual do menu
                document.querySelectorAll('.nav-link').forEach(link => link.classList.remove('active'));
                this.classList.add('active');
            }
        });
    }

    // Manipula navegação do histórico
    window.addEventListener('popstate', function() {
        const currentPath = window.location.pathname;
        const relevantLink = document.querySelector(`[href="${currentPath}"]`);
        if (relevantLink) {
            relevantLink.click();
        }
    });
});

// Simulação de clique nos itens do chat
document.addEventListener('DOMContentLoaded', function() {
    const chatItems = document.querySelectorAll('.chat-item');
    
    chatItems.forEach(item => {
        item.addEventListener('click', function() {
            const userName = this.querySelector('h6').textContent;
            alert(`Chat com ${userName} será implementado em breve!`);
        });
    });
});
